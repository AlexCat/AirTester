using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HidLibrary;

namespace Tion.MagicAirTester.Contracts
{
    public interface ILiveParser
    {
        IBreezerState Parse(HidReport data);
    }
}
