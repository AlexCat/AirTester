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

        public CommandExecutor<Bs310Command> CreateBs310Tester()
        {
            var scenario1 = new List<Bs310Command>()
            {
               // new Bs310Command("logenable"),
                new Bs310Command(1, "upvent 1", new BS310CommandResult()),
                new Bs310Command(1, "upvent 1", new BS310CommandResult()),
                new Bs310Command(1, "upvent 1", new BS310CommandResult()),
                new Bs310Command(1, "upvent 1", new BS310CommandResult()),
                new Bs310Command(1, "upvent 1", new BS310CommandResult()),
                new Bs310Command(1, "upvent 1", new BS310CommandResult()),
                new Bs310Command(1, "", new BS310CommandResult()),
            };
            return new CommandExecutor<Bs310Command>(scenario1, new Bs310Parser<Bs310Command>(), _deviceFinderFactory.CreateBS310Finder());
        }
    }
}
