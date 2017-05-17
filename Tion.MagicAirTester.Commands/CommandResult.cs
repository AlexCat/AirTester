using System.Data;
using Tion.MagicAirTester.MagicAirBS310;

namespace Tion.MagicAirTester.Commands
{
    public abstract class CommandResult
    {
        /// <summary>
        /// Contains result of command execution
        /// </summary>
        public bool Ok { get; set; }

        public DeviceCommandType Property { get; protected set; }
        public object Value { get; protected set; }
    }
}