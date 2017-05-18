using Tion.MagicAirTester.Contracts;
using Tion.MagicAirTester.Forms;
using Tion.MagicAirTester.Infrastructure.Factories;
using Tion.MagicAirTester.Infrastructure.Services;

namespace Tion.DeviceTester.Infrastructure.Factories {

    /// <summary>
    /// Forms factory
    /// </summary>
    public class FormFactory {
        private readonly ExecutorsFactory _executorsFactory;
        private readonly IOutputService _outputService;
        private readonly ILiveParser _liveParser;
        private readonly ILocalizationService _localizationService;
        

        public FormFactory(ExecutorsFactory executorsFactory, IOutputService outputService, ILiveParser liveParser, ILocalizationService localizationService)
        {
            _executorsFactory = executorsFactory;
            _outputService = outputService;
            _liveParser = liveParser;
            _localizationService = localizationService;
        }

        public FormMain CreateMainForm() {
            return new FormMain(this, _executorsFactory, _outputService, _liveParser, _localizationService);
        }
    }
}
