using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Tion.MagicAirTester.Contracts;
using Tion.MagicAirTester.Properties;

namespace Tion.MagicAirTester.Infrastructure.Services
{
    public class LocalizationService : ILocalizationService
    {

        private readonly Dictionary<string, ResourceSet> _dictionary = new Dictionary<string, ResourceSet>();
        private CultureInfo _culture;
        private readonly string[] _resourceForShellNames = { "Properties.Resources" };
        private readonly string[] _resourceForPluginsNames = { "Resources" };

        public LocalizationService()
        {
            InitializeLocale();

            // Shell application resource builder
            var assemblyShell = typeof(Program).Assembly;
            var resourceManifestNames = assemblyShell.GetManifestResourceNames();

            foreach (var name in _resourceForShellNames)
            {
                var resourceName = resourceManifestNames.SingleOrDefault(x => x.Contains(name));
                AddDictionary(resourceName, assemblyShell);
            }

            // Plugins for shell resources builder
            var plugins = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName.Contains("Tion.Devices.")).ToList();
            if (!plugins.Any()) return;
            foreach (var plugin in plugins)
            {
                var manifestResourceNames = plugin.GetManifestResourceNames();
                if (!manifestResourceNames.Any()) continue;
                foreach (var name in _resourceForPluginsNames)
                {
                    var resourceName = manifestResourceNames.First();//;.SingleOrDefault(x => x.Contains(name));
                    AddDictionary(resourceName, plugin);
                }
            }
        }

        private void AddDictionary(string resourceName, Assembly assembly)
        {
            if (resourceName != null)
            {
                var resourceManager = GetResourceManager(resourceName, assembly);
                var resourceSet = resourceManager.GetResourceSet(CultureInfo.GetCultureInfo(Settings.Default.Locale), true, true);
                if (resourceSet == null) throw new Exception("Unable to create ResourceSet.");
                _dictionary.Add($"{resourceName}", resourceSet);
            }
            else throw new MissingManifestResourceException();
        }

        private ResourceManager GetResourceManager(string resourceName, Assembly assembly)
        {
            var ls = resourceName.LastIndexOf(".", StringComparison.Ordinal);
            var name = resourceName.Substring(0, ls);
            return new ResourceManager(name, assembly);

        }

        public string GetValue(string key)
        {
            foreach (var resource in _dictionary)
            {
                var value = resource.Value.GetString(key, true);
                if (!string.IsNullOrEmpty(value))
                {
                    return value;
                }
            }
            return $"{key} not found";
        }

        public IEnumerable<LocaleInfo> Locales {
            get {
                yield return new LocaleInfo { Code = "en-US", Name = "English" };
                yield return new LocaleInfo { Code = "ru-RU", Name = "Russian" };
                yield return new LocaleInfo { Code = "zh-CHS", Name = "Chinese" };
            }
        }

        public void ChangeLanguage(string lang)
        {
            foreach (var form in Application.OpenForms)
            {
                foreach (var ctl in ((Form)form).Controls)
                {
                    var manager = new ComponentResourceManager(form.GetType());
                    manager.ApplyResources(ctl, ((Control)ctl).Name, new CultureInfo(lang));
                }
            }
        }

        private void InitializeLocale()
        {
            try
            {
                _culture = new CultureInfo(Settings.Default.Locale, false);
                Thread.CurrentThread.CurrentCulture = _culture;
                Thread.CurrentThread.CurrentUICulture = _culture;
            }
            catch
            {
                _culture = new CultureInfo("en-US", false);
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US", false);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US", false);
            }
        }
        public void Initialize()
        {
            InitializeLocale();
        }
    }
}
