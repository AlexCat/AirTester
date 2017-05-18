using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tion.MagicAirTester.Contracts
{
    public class LocaleInfo
    {

        /// <summary>
        /// The name of the Locale
        /// Smaple: Russian, English, Chinesse
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The code of the Locale.
        /// Sample: ru-RU, en-US
        /// </summary>
        public string Code { get; set; }
    }
}
