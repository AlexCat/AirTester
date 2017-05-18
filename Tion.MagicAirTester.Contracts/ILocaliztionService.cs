using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tion.MagicAirTester.Contracts
{
    public interface ILocalizationService
    {
        /// <summary>
        /// Returns translates resource
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string GetValue(string key);

        /// <summary>
        /// List of avaliable locales info
        /// </summary>
        IEnumerable<LocaleInfo> Locales { get; }

        /// <summary>
        /// Process Resouces to find locales
        /// </summary>
        void Initialize();

        /// <summary>
        /// Change locale to another language
        /// </summary>
        /// <param name="language">ex. "ru-Ru"</param>
        void ChangeLanguage(string language);
    }
}
