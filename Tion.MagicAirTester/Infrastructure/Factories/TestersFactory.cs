using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HidLibrary;
using Tion.MagicAirTester.Commands;
using Tion.MagicAirTester.Contracts;
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
                //new Bs310Command(1, "pairing 0 1", 5000, new BS310CommandResult(Bs310CommandResultProperty.PairingWithBreezer3S, "6")),
                new Bs310Command(0, "upvent 1", 1000, new BS310CommandResult(Bs310CommandResultProperty.PairingWithBreezer3S, "4")),
                new Bs310Command(1, "upvent 1", 1000, new BS310CommandResult(Bs310CommandResultProperty.PairingWithBreezer3S, "5")),
                new Bs310Command(2, "upvent 1", 1000, new BS310CommandResult(Bs310CommandResultProperty.PairingWithBreezer3S, "6")),
                new Bs310Command(3, "dwnvent 1", 1000, new BS310CommandResult(Bs310CommandResultProperty.PairingWithBreezer3S, "5")),
                new Bs310Command(4, "dwnvent 1", 1000, new BS310CommandResult(Bs310CommandResultProperty.PairingWithBreezer3S, "4")),
                new Bs310Command(5, "dwnvent 1", 1000, new BS310CommandResult(Bs310CommandResultProperty.PairingWithBreezer3S, "3"))
            };
            return new CommandExecutor<Bs310Command>(scenario1, new Bs310Parser<Bs310Command>(), _deviceFinderFactory.CreateBS310Finder());
        }
    }
}
