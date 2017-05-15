using System.Linq;
using System.Text;

namespace Tion.MagicAirTester.Commands
{
    public class Bs310Command : Command
    {
        public BS310CommandResult CommandResult { get; }

        public Bs310Command(int orderId, string commandName, int timeToExecute, BS310CommandResult commandResult)
        {
            CommandResult = commandResult;
            OrderId = orderId;
            CommandName = commandName;
            BytesCommand = ConvertToBytes(commandName);
            TimeToExecute = timeToExecute;
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