using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HidLibrary;
using Tion.MagicAirTester.Contracts;

namespace Tion.MagicAirTester.Tester
{
    public class LiveBS310Parser : ILiveParser
    {
        public IBreezerState Parse(HidReport data)
        {
            return new BreezerState(){Speed = 8000};
        }
    }
}
