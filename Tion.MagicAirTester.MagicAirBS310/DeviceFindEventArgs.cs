using System;
using HidLibrary;

namespace Tion.MagicAirTester.MagicAirBS310
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
