namespace Tion.MagicAirTester.Commands
{
    public class CommandResult
    {
        /// <summary>
        /// Contains result of command execution
        /// </summary>
        public bool Ok { get; set; }

        public Bs310CommandResultProperty Property { get; protected set; }
        public object Value { get; protected set; }
    }
}