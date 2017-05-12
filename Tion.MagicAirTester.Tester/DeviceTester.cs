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
    public class DeviceTester<T> : IDisposable where T : Command
    {
        private readonly Queue<T> _commands;
        private readonly IParser<T> _parser;
        private readonly IDeviceFinder _finder;
        private IHidDevice _hidDevice;
        private StringBuilder _currentCommandReport;
        private T _currentCommand;

        public DeviceTester(IEnumerable<T> commands, IParser<T> parser, IDeviceFinder finder)
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

        public void Run(bool testAutomatically)
        {
            _finder.Run(device =>
            {
                _hidDevice = device;
                //
                //_hidDevice.OpenDevice();
                //_hidDevice.Write(ConvertToBytes("logenable"));
                //_hidDevice.CloseDevice();

                //
                if (testAutomatically)
                {
                    _currentCommand = _commands.Dequeue();
                    ExecuteAutoCommand();
                }
            });
        }

        private void ExecuteAutoCommand()
        {
            if (_currentCommand != null)
            {
                _hidDevice.OpenDevice();
                _hidDevice.MonitorDeviceEvents = true;

                _currentCommandReport = new StringBuilder();
                WaitExecutionCommandResult();
                //_hidDevice.ReadReport(report =>
                //{
                //    var result = Encoding.ASCII.GetString(report.Data);
                //    Debug.WriteLine(result);
                //    //_currentCommandReport.AppendFormat(result);
                //});
                //
                _hidDevice.ReadReport(OnReportAction);
               // ExcecuteCommand();
            }
        }

        public object key = new object();
        private void OnReportAction(HidReport report)
        {
            if (!_hidDevice.IsConnected)
            {
                throw new Exception();
            }

            var str = Encoding.ASCII.GetString(report.Data);
            //Debug.WriteLine();
            //_currentCommandReport.AppendLine();
            //Debug.WriteLine(_currentCommandReport.Length);
            str.WriteToFile(@"C:\MD\helloworld.txt");
            _hidDevice.ReadReport(OnReportAction);
        }

        private void WaitExecutionCommandResult()
        {
            var timer = new Timer(5000);
            timer.Elapsed += (sender, args) =>
            {
                timer.Stop();
                _hidDevice.CloseDevice();
                
                _parser.CheckResult(_currentCommand, string.Copy(_currentCommandReport.ToString()));
                if (_commands.Any())
                {
                    _currentCommand = _commands.Dequeue();
                    ExecuteAutoCommand();
                    timer.Start();
                }
            };
            timer.Start();
        }

        private void OnReport(HidReport report)
        {
            if (!_hidDevice.IsConnected)
            {
                throw new Exception();
            }

            var str = Encoding.ASCII.GetString(report.Data);
            Debug.WriteLine(str);

            _hidDevice.ReadReport(OnReport);
        }

        public bool ExcecuteCommand()
        {
            var result = _hidDevice.Write(_currentCommand.BytesCommand);

            if (!result)
            {
                throw new Exception();
            }

            return false;
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
