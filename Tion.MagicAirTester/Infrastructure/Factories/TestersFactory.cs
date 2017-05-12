using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HidLibrary;
using Tion.MagicAirTester.Commands;
using Tion.MagicAirTester.Tester;

namespace Tion.MagicAirTester.Infrastructure.Factories
{
    public class TestersFactory
    {
        private readonly DeviceFinderFactory _deviceFinderFactory;

        public TestersFactory(DeviceFinderFactory deviceFinderFactory)
        {
            _deviceFinderFactory = deviceFinderFactory;
        }

        public DeviceTester<BS310Command> CreateBs310Tester()
        {
            var commands = new List<BS310Command>()
            {
               // new BS310Command("logenable"),
                new BS310Command(1, "help", new BS310CommandResult("Speed", "1"))
            };
            return new DeviceTester<BS310Command>(commands, new BS310Parser<BS310Command>(), _deviceFinderFactory.CreateBS310Finder());
        }
    }
}
