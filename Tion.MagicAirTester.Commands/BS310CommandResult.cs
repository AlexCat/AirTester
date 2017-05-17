using System;

namespace Tion.MagicAirTester.Commands
{
    public class BS310CommandResult : CommandResult
    {
        public BS310CommandResult(Bs310CommandResultProperty property, object value)
        {
            Property = property;
            Value = value;
            IsResultNeeded = true;
        }
        
        public bool IsResultNeeded { get; }
    }
}