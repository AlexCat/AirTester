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
            return ParseData(str);
        }

        private BreezerState ParseData(string data)
        {
            var breezer = new BreezerState();

            // is connected
            Regex isConnectedReg = new Regex("br 2");
            var isConnectedRegResult = isConnectedReg.Match(data);
            if (isConnectedRegResult.Success)
            {
                breezer.IsConnected = true;
            }

            // speed
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
