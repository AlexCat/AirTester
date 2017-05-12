using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tion.MagicAirTester.Contracts;
using Tion.MagicAirTester.DeviceFinder;

namespace Tion.MagicAirTester.Infrastructure.Factories
{
    public class DeviceFinderFactory
    {
        public BS310DeviceFinder CreateBS310Finder()
        {
            return new BS310DeviceFinder(3000, 0x2D45, 0x3100);
        } 
    }
}
