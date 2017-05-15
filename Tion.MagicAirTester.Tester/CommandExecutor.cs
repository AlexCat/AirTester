using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using HidLibrary;
using Tion.MagicAirTester.Commands;
using Tion.MagicAirTester.Contracts;
using Timer = System.Timers.Timer;

namespace Tion.MagicAirTester.Tester
{
    public class CommandExecutor<T> : IDisposable where T : Command
    {
        private readonly Queue<T> _commands;
        private readonly IParser<T> _parser;
        private readonly IDeviceFinder _finder;
        private IHidDevice _hidDevice;
        private List<string> _currentCommandReport;
        private T _currentCommand;

        public CommandExecutor(IEnumerable<T> commands, IParser<T> parser, IDeviceFinder finder)
        {
            _commands = new Queue<T>(commands.OrderBy(x => x.OrderId));
            _parser = parser;
            _finder = finder;
        }


        public static byte[] ConvertToBytes(string command)
        {
            var bytesCommand = Encoding.ASCII.GetBytes(command).ToList();
            bytesCommand.Insert(0, 0x0A);
            bytesCommand.Insert(bytesCommand.Count, 0x0D);
            return bytesCommand.ToArray();
        }

        public void StartAutotest()
        {
            _finder.Run(device =>
            {
                _hidDevice = device;
                _currentCommand = _commands.Dequeue();
                ExecuteAutoCommand();
            });
        }

        private void ExecuteAutoCommand()
        {
            if (_currentCommand != null)
            {
                _hidDevice.OpenDevice();
                _hidDevice.MonitorDeviceEvents = true;

                _currentCommandReport = new List<string>();
                WaitExecutionCommandResult();
                
                _hidDevice.ReadReport(OnReportAction);
                _hidDevice.Write(_currentCommand.BytesCommand);
            }
        }

        private void OnReportAction(HidReport report)
        {
            if (!_hidDevice.IsConnected)
            {
                throw new Exception();
            }

            var str = Encoding.ASCII.GetString(report.Data);
            Debug.WriteLine(str);
            _currentCommandReport.Add(str);
            _hidDevice.ReadReport(OnReportAction);
        }

        private void WaitExecutionCommandResult()
        {
            var timer = new Timer(_currentCommand.TimeToExecute);
            timer.Elapsed += (sender, args) =>
            {
                timer.Stop();
                _hidDevice.CloseDevice();
                _parser.CheckResult(_currentCommand, _currentCommandReport);

                if (_commands.Any())
                {
                    _currentCommand = _commands.Dequeue();
                    ExecuteAutoCommand();
                    timer.Start();
                }
            };
            timer.Start();
        }

        public void ExecuteSingleCommand()
        {
            
        }

        public void Dispose()
        {
            _hidDevice?.Dispose();
        }
    }

    public static class Strings
    {
        /// <summary>
        /// Extension method to write the string Str to a file
        /// </summary>
        /// <param name="Str"></param>
        /// <param name="Filename"></param>
        public static void WriteToFile(this string Str, string Filename)
        {
            File.WriteAllText(Filename, Str);
            return;
        }

        // of course you could add other useful string methods...
    }
}
