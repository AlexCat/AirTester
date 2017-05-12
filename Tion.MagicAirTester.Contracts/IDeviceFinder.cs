using System;
using HidLibrary;

namespace Tion.MagicAirTester.Contracts
{
    public interface IDeviceFinder
    {
        void Run(Action<IHidDevice> action);
    }
}