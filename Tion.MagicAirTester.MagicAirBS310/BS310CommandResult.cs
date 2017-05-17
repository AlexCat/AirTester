using Tion.MagicAirTester.Commands;

namespace Tion.MagicAirTester.MagicAirBS310
{
    public class BS310CommandResult : CommandResult
    {
        public BS310CommandResult(DeviceCommandType property, object value)
        {
            Property = property;
            Value = value;
            IsResultNeeded = true;
        }
        
        public bool IsResultNeeded { get; }
    }
}