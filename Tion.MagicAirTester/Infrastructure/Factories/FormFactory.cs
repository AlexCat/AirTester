using Tion.MagicAirTester.Forms;

namespace Tion.DeviceTester.Infrastructure.Factories {

    /// <summary>
    /// Forms factory
    /// </summary>
    public class FormFactory {
        //private readonly ILocalizationService _localizationService;
        //private readonly AppTimer _timer;
        //private readonly IOutputService _outputService;
        //private readonly IEnumerable<IDevice> _devices;

        public FormFactory() {
            
        }

        public FormMain CreateMainForm() {
            return new FormMain(this);
        }
    }
}
