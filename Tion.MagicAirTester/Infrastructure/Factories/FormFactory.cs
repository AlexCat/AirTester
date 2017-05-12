using Tion.MagicAirTester.Contracts;
using Tion.MagicAirTester.Forms;
using Tion.MagicAirTester.Infrastructure.Factories;

namespace Tion.DeviceTester.Infrastructure.Factories {

    /// <summary>
    /// Forms factory
    /// </summary>
    public class FormFactory {
        private readonly TestersFactory _testersFactory;
        //private readonly ILocalizationService _localizationService;
        //private readonly AppTimer _timer;
        //private readonly IOutputService _outputService;
        //private readonly IEnumerable<IDevice> _devices;

        public FormFactory(TestersFactory testersFactory)
        {
            _testersFactory = testersFactory;
        }

        public FormMain CreateMainForm() {
            return new FormMain(this, _testersFactory);
        }
    }
}
