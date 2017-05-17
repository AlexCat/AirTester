using System.Linq;
using System.Text;
using Tion.MagicAirTester.Commands;

namespace Tion.MagicAirTester.MagicAirBS310
{
    public class Bs310Command : Command
    {
        public Bs310Command(int orderId, string commandName, int timeToExecute, BS310CommandResult commandResult, bool isResultNeed = true)
        {
            CommandResult = commandResult;
            OrderId = orderId;
            CommandName = commandName;
            BytesCommand = ConvertToBytes(commandName);
            TimeToExecute = timeToExecute;
            IsResultNeeded = isResultNeed;
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