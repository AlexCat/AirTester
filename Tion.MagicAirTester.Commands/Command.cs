using System.Linq;
using System.Text;

namespace Tion.MagicAirTester.Commands
{
    public abstract class Command
    {
        public string CommandName { get; set; }
        public byte[] BytesCommand { get; set; }
        public int OrderId { get; set; }
    }

    public class CommandResult
    {
    }

    public class BS310CommandResult : CommandResult
    {
        public BS310CommandResult(string property, string value)
        {
            property = Property;
            value = Value;
        }
        public string Property { get; }
        public string Value { get; }
    }

    public class BS310Command : Command
    {
        public BS310CommandResult CommandResult { get; }

        public BS310Command(int orderId, string commandName, BS310CommandResult commandResult)
        {
            CommandResult = commandResult;
            OrderId = orderId;
            CommandName = commandName;
            BytesCommand = ConvertToBytes(commandName);
        }

        public static byte[] ConvertToBytes(string command)
        {
            var bytesCommand = Encoding.ASCII.GetBytes(command).ToList();
            bytesCommand.Insert(0, 0x0A);
            bytesCommand.Insert(bytesCommand.Count, 0x0D);
            return bytesCommand.ToArray();
        } 
    }
}
