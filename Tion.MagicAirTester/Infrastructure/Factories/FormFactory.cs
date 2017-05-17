using Tion.MagicAirTester.Contracts;
using Tion.MagicAirTester.Forms;
using Tion.MagicAirTester.Infrastructure.Factories;

namespace Tion.DeviceTester.Infrastructure.Factories {

    /// <summary>
    /// Forms factory
    /// </summary>
    public class FormFactory {
        private readonly ExecutorsFactory _executorsFactory;

        private readonly IOutputService _outputService;

        private readonly ILiveParser _liveParser;
        //private readonly ILocalizationService _localizationService;
        //private readonly AppTimer _timer;
        //private readonly IOutputService _outputService;
        //private readonly IEnumerable<IDevice> _devices;

        public FormFactory(ExecutorsFactory executorsFactory, IOutputService outputService, ILiveParser liveParser)
        {
            _executorsFactory = executorsFactory;
            _outputService = outputService;
            _liveParser = liveParser;
        }

        public FormMain CreateMainForm() {
            return new FormMain(this, _executorsFactory, _outputService, _liveParser);
        }
    }
}
