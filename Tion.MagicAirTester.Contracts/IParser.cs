using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tion.MagicAirTester.Commands;

namespace Tion.MagicAirTester.Contracts
{
    public interface IParser<in T>
    {
        bool CheckResult(T currentCommand, List<string> data);
    }
}
