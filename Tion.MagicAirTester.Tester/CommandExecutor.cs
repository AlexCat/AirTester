using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using HidLibrary;
using Tion.MagicAirTester.Commands;
using Tion.MagicAirTester.Contracts;

namespace Tion.MagicAirTester.Tester
{
    public class CommandExecutor<T> : IDisposable where T : Command
    {
        private readonly IBreezerState _breezerState;
        private readonly Queue<T> _commands;
        private readonly IDeviceFinder _finder;
        private List<Command> _autoCommandsResult;
        private T _currentCommand;
        private IHidDevice _hidDevice;
        private Action<LogType, string> _outputAction;
        private bool _disposed;
        private Timer _tm;

        public event EventHandler<MagicAirDataReceivedArgs> MagicAirDataReceived;
        public event EventHandler MagicAirFound;
        public event EventHandler<TestFinishedArgs> TestFinished;

        public CommandExecutor(IEnumerable<T> commands, IDeviceFinder finder, IBreezerState breezerState)
        {
            _commands = new Queue<T>(commands.OrderBy(x => x.OrderId));
            _finder = finder;
            _breezerState = breezerState;
        }

        // Public implementation of Dispose pattern callable by consumers.

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Start(Action<LogType, string> outputAction)
        {
            _outputAction = outputAction;
            _outputAction?.Invoke(LogType.Info, "Finding MagicAir BS310...");
            var timer = new System.Timers.Timer(7000);
            timer.Elapsed += (sender, args) =>
            {
                timer.Stop();
                _outputAction?.Invoke(LogType.Info, "MagicAir BS310 not found");
            };
            _finder.Run(device =>
            {
                timer.Stop();
                _hidDevice = device;
                _outputAction?.Invoke(LogType.Info, "MagicAir BS310 found");
                OnMagicAirFound();

                // Permanent reading for state refresh
                _hidDevice.ReadReport(PermanentMagicAirDataReader);
            });
            timer.Start();
        }

        public void StartTest()
        {
            _outputAction?.Invoke(LogType.Info, "Automatic test started...");

            _hidDevice.MonitorDeviceEvents = true;
            _autoCommandsResult = new List<Command>();

            ExecuteNextCommand();
        }

        private void ExecuteNextCommand()
        {
            // извлекаем новую команаду
            _currentCommand = _commands.Dequeue();

            // кидаем команду
            _outputAction?.Invoke(LogType.Info, $"Send command \"{_currentCommand.CommandName}\" ({BitConverter.ToString(_currentCommand.BytesCommand)})");
            _hidDevice.Write(_currentCommand.BytesCommand);

            // запускаем отложенную проверку / запуск рекурсии
            _tm = new Timer(OnTimerAction, null, _currentCommand.TimeToExecute, 0);
        }

        private void OnTimerAction(object state)
        {
            CheckResult();

            // проверка на рекурсию или ее завершение
            if (_commands.Any())
            {
                ExecuteNextCommand();
            }
            else
            {
                _currentCommand = null;
                _tm = null;
                OnTestFinished(_autoCommandsResult);
                _outputAction?.Invoke(LogType.Info, "Automatic test finished");
            }
        }

        private void CheckResult()
        {
            // check speed
            if (_currentCommand.CommandResult.Property == Bs310CommandResultProperty.Speed)
            {
                _currentCommand.CommandResult.Ok = Convert.ToInt32(_currentCommand.CommandResult.Value) == _breezerState.Speed;
            }

            _autoCommandsResult.Add(_currentCommand);
        }

        private void PermanentMagicAirDataReader(HidReport report)
        {
            if (!_hidDevice.IsConnected)
            {
                throw new Exception();
            }

            OnMagicAirDataReceived(new MagicAirDataReceivedArgs {Report = report});
            _hidDevice.ReadReport(PermanentMagicAirDataReader);
        }

        protected virtual void OnMagicAirDataReceived(MagicAirDataReceivedArgs e)
        {
            MagicAirDataReceived?.Invoke(this, e);
        }

        protected virtual void OnMagicAirFound()
        {
            MagicAirFound?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnTestFinished(List<Command> result)
        {
            TestFinished?.Invoke(this, new TestFinishedArgs {Result = result});
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                // ReSharper disable once RedundantCheckBeforeAssignment
                if (_hidDevice != null)
                {
                    _hidDevice = null;
                }

                if (MagicAirDataReceived != null || MagicAirFound != null)
                {
                    MagicAirDataReceived = null;
                    MagicAirFound = null;
                }
            }

            // Free any unmanaged objects here.
            _disposed = true;
        }

        public void ExecuteSingleCommand(T command, Action onCommandExecuteAction)
        {
            _hidDevice.Write(command.BytesCommand);

            var timer = new System.Timers.Timer(command.TimeToExecute);
            timer.Elapsed += (sender, args) =>
            {
                timer.Stop();
                onCommandExecuteAction();
            };
            timer.Start();
        }
    }

    public class TestFinishedArgs : EventArgs
    {
        public List<Command> Result { get; set; }
    }

    public class MagicAirDataReceivedArgs : EventArgs
    {
        public HidReport Report { get; set; }
    }
}