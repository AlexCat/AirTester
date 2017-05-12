using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using HidLibrary;
using Tion.MagicAirTester.Contracts;
using Timer = System.Timers.Timer;

namespace Tion.MagicAirTester.DeviceFinder
{
    public class BS310DeviceFinder : IDeviceFinder
    {
        public BS310DeviceFinder(double findInterval, int hexVendorId, int hexProductId)
        {
            _findInterval = findInterval;
            _hexVendorId = hexVendorId; // 0x2D45
            _hexProductId = hexProductId; // 0x3100
        }

        private Timer _timer;

        public void Run(Action<IHidDevice> action)
        {
            _action = action;
            _timer = new Timer(_findInterval);
            _timer.Elapsed += OnTimerElapsed;
            _timer.Start();
        }

        private readonly double _findInterval;
        private readonly int _hexVendorId;
        private readonly int _hexProductId;
        private Action<IHidDevice> _action;

        void OnTimerElapsed(object eventSender, ElapsedEventArgs e)
        {
            var device = HidDevices.Enumerate(_hexVendorId, _hexProductId).FirstOrDefault();
            if (device != null)
            {
                _action(device);
                _timer.Stop();
            }
        }
    }
}
