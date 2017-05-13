namespace Tion.MagicAirTester.Commands
{
    public class BS310CommandResult : CommandResult
    {
        public BS310CommandResult(Bs310CommandResultProperty property, string value)
        {
            property = Property;
            value = Value;
        }
        public Bs310CommandResultProperty Property { get; }
        public string Value { get; }
    }
}