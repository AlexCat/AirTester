using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Timers;
using HidLibrary;
using Tion.MagicAirTester.Commands;
using Tion.MagicAirTester.Contracts;
using System.Threading;


namespace Tion.MagicAirTester.Tester
{
    public class CommandExecutor<T> : IDisposable where T : Command
    {
        private readonly Queue<T> _commands;
        private readonly IDeviceFinder _finder;
        private readonly IBreezerState _breezerState;
        private readonly AppTimer _appTimer;
        private IHidDevice _hidDevice;
        private T _currentCommand;
        private List<Command> _autoCommandsResult;
        private Action<LogType, string> _outputAction;
        public event EventHandler<DeviceFoundArgs> DeviceDataReceived;
        public event EventHandler DeviceFound;
        public event EventHandler<AutocommandsResult> TestFinished;
        

        public CommandExecutor(IEnumerable<T> commands, IDeviceFinder finder, IBreezerState breezerState, AppTimer appTimer)
        {
            _commands = new Queue<T>(commands.OrderBy(x => x.OrderId));
            _finder = finder;
            _breezerState = breezerState;
            _appTimer = appTimer;
        }

        public void StartAutotest()
        {
            _outputAction?.Invoke(LogType.Info, "Automatic test started...");
            _autoCommandsResult = new List<Command>();

            ExecuteAutoCommand();
        }

        public void Start(Action<LogType, string> outputAction)
        {
            _outputAction = outputAction;
            _outputAction?.Invoke(LogType.Info, "Finding MagicAir BS310...");
            var timer = new Timer(7000);
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
                OnDeviceFound();

                // Permanent reading for state refresh
                _hidDevice.ReadReport(OnMagicAirFindAction);
            });
            timer.Start();
        }

        private void ExecuteAutoCommand()
        {
            _currentCommand = _commands.Dequeue();

            _hidDevice.OpenDevice();
            _hidDevice.MonitorDeviceEvents = true;

            _outputAction?.Invoke(LogType.Info, $"Send command \"{_currentCommand.CommandName}\" ({BitConverter.ToString(_currentCommand.BytesCommand)})");

            _hidDevice.Write(_currentCommand.BytesCommand);
            WaitExecutionCommandResult(); 
        }

        private void WaitExecutionCommandResult()
        {
            _appTimer.Initialize(_currentCommand.TimeToExecute);

            _appTimer.TimerComplete += OnTimerComplete;
            _appTimer.Start();
        }

        private void OnTimerComplete(object o, EventArgs elapsedEventArgs)
        {
            _appTimer.Stop();
            _appTimer.TimerComplete -= OnTimerComplete;

            _hidDevice.CloseDevice();

            Debug.WriteLine($"{DateTime.Now} {_currentCommand.OrderId}");

            // check
            if (_currentCommand.CommandResult.Property == Bs310CommandResultProperty.Speed)
            {
                _currentCommand.CommandResult.Ok = Convert.ToInt32(_currentCommand.CommandResult.Value) == _breezerState.Speed;
            }
            _autoCommandsResult.Add(_currentCommand);
            // end check

            if (_commands.Any())
            {
                ExecuteAutoCommand();
            }
            else
            {
                OnTestFinished(_autoCommandsResult);
            }
        }

        private void OnMagicAirFindAction(HidReport report)
        {
            if (!_hidDevice.IsConnected)
            {
                throw new Exception();
            }

            OnDeviceDataReceived(new DeviceFoundArgs() { Report = report });
            _hidDevice.ReadReport(OnMagicAirFindAction);
        }

        protected virtual void OnDeviceDataReceived(DeviceFoundArgs e)
        {
            DeviceDataReceived?.Invoke(this, e);
        }

        bool disposed = false;

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                // ReSharper disable once RedundantCheckBeforeAssignment
                if (_hidDevice != null)
                {
                    _hidDevice = null;
                }

                if (DeviceDataReceived != null || DeviceFound != null)
                {
                    DeviceDataReceived = null;
                    DeviceFound = null;
                }

                _appTimer?.Dispose();
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }

        public void ExecuteSingleCommand(T command, Action onCommandExecuteAction)
        {
            _hidDevice.Write(command.BytesCommand);

            var timer = new Timer(command.TimeToExecute);
            timer.Elapsed += (sender, args) =>
            {
                timer.Stop();
                onCommandExecuteAction();
            };
            timer.Start();
        }

        protected virtual void OnDeviceFound()
        {
            DeviceFound?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnTestFinished(List<Command> result)
        {
            TestFinished?.Invoke(this, new AutocommandsResult(){Result = result});
        }
    }

    public class AutocommandsResult : EventArgs
    {
        public List<Command> Result { get; set; }
    }

    public class DeviceFoundArgs : EventArgs
    {
        public HidReport Report { get; set; }
    }
}
