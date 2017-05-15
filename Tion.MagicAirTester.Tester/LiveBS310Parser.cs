using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HidLibrary;
using Tion.MagicAirTester.Contracts;

namespace Tion.MagicAirTester.Tester
{
    public class LiveBS310Parser : ILiveParser
    {
        public IBreezerState Parse(HidReport data)
        {
            var str = Encoding.ASCII.GetString(data.Data);
            return ParseState(str);
        }

        private BreezerState ParseState(string data)
        {
            var breezer = new BreezerState();
            Regex speedReg = new Regex("SpR=\\d+");
            var res = speedReg.Match(data);
            if (res.Success)
            {
                var speedStr = res.Value.Split(new char[] {'='}, StringSplitOptions.RemoveEmptyEntries)[1];
                breezer.Speed = Int32.Parse(speedStr);
            }
            return breezer;
        }
    }
}
