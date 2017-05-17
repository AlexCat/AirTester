using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tion.MagicAirTester.Commands;
using Tion.MagicAirTester.Contracts;
using Tion.MagicAirTester.MagicAirBS310;

namespace Tion.MagicAirTester.Infrastructure.Factories
{
    public class ScenariesBuilder
    {
        private readonly IBreezerState _initState;
        private List<Command> _commandsList;

        public ScenariesBuilder(IBreezerState initState, List<Command> commandsList)
        {
            _initState = initState;
            _commandsList = commandsList;
        }

        public List<Command> GetCommands(IBreezerState actualState)
        {
            if (actualState.Speed != _initState.Speed)
            {
                EqualSpeed();
            }

            return _commandsList.OrderBy(x => x.OrderId).ToList();
        }

        private void EqualSpeed()
        {
            var list = new List<Command>
            {
                new Bs310Command(0, "dwnvent 1", 2000, new BS310CommandResult(DeviceCommandType.Speed, "0"), false), //5
                new Bs310Command(1, "dwnvent 1", 2000, new BS310CommandResult(DeviceCommandType.Speed, "0"), false), //4
                new Bs310Command(2, "dwnvent 1", 2000, new BS310CommandResult(DeviceCommandType.Speed, "0"), false), //3
                new Bs310Command(3, "dwnvent 1", 2000, new BS310CommandResult(DeviceCommandType.Speed, "0"), false), //2
                new Bs310Command(4, "dwnvent 1", 2000, new BS310CommandResult(DeviceCommandType.Speed, "0"), false), //1
            };

            for (int i = 1; i < _initState.Speed; i++)
            {
                list.Add(new Bs310Command(i + 10, "upvent 1", 2000, new BS310CommandResult(DeviceCommandType.Speed, "0"), false)); 
            }

            _commandsList = _commandsList.Concat(list).ToList();
        }
    }
}
