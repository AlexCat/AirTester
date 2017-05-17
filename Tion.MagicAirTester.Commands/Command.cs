namespace Tion.MagicAirTester.Commands
{
    public abstract class Command
    {
        public string CommandName { get; set; }
        public byte[] BytesCommand { get; set; }
        public int OrderId { get; set; }
        /// <summary>
        /// Waiting time to collect data after command executes
        /// </summary>
        public int TimeToExecute { get; set; }
        public CommandResult CommandResult { get; set; }
    }
}
