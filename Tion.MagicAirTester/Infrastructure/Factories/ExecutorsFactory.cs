using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HidLibrary;
using Tion.MagicAirTester.Commands;
using Tion.MagicAirTester.Contracts;
using Tion.MagicAirTester.MagicAirBS310;
using Tion.MagicAirTester.Tester;

namespace Tion.MagicAirTester.Infrastructure.Factories
{
    public class ExecutorsFactory
    {
        private readonly DeviceFinderFactory _deviceFinderFactory;

        public ExecutorsFactory(DeviceFinderFactory deviceFinderFactory)
        {
            _deviceFinderFactory = deviceFinderFactory;
        }

        public CommandExecutor<Bs310Command> CreateBs310Tester(IBreezerState breezerState)
        {
            var cmd = new List<Command>()
            {
                new Bs310Command(100, "upvent 1", 2000, new BS310CommandResult(DeviceCommandType.Speed, 3)), // 4
                new Bs310Command(101, "upvent 1", 2000, new BS310CommandResult(DeviceCommandType.Speed, 3)), // 5
                new Bs310Command(102, "upvent 1", 2000, new BS310CommandResult(DeviceCommandType.Speed, 3)), // 6
                new Bs310Command(103, "dwnvent 1", 2000, new BS310CommandResult(DeviceCommandType.Speed, 3)), // 5
                new Bs310Command(104, "dwnvent 1", 2000, new BS310CommandResult(DeviceCommandType.Speed, 3)), // 4
                new Bs310Command(105, "dwnvent 1", 2000, new BS310CommandResult(DeviceCommandType.Speed, 3)), // 3
                new Bs310Command(105, "deldev 1", 2000, new BS310CommandResult(DeviceCommandType.UnpairWithBreezer3S, ""), false), // 3
            };
            var b = new ScenariesBuilder(new Breezer3SState() { Speed = 3 }, cmd);
            return new CommandExecutor<Bs310Command>(b, _deviceFinderFactory.CreateBS310Finder(), breezerState);
        }
    }
}
