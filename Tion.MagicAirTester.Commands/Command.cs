namespace Tion.MagicAirTester.Commands
{
    public abstract class Command
    {
        public string CommandName { get; set; }
        public byte[] BytesCommand { get; set; }
        public int OrderId { get; set; }
    }
}
