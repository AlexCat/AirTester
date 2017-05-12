using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HidLibrary;

namespace Tion.MagicAirTester.DeviceFinder
{
    public class DeviceFindEventArgs : EventArgs
    {
        public IHidDevice HidDevice { get; }

        public DeviceFindEventArgs(IHidDevice hidDevice)
        {
            HidDevice = hidDevice;
        }
    }
}
