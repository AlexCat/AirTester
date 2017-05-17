using System;
using System.Windows.Forms;
using Tion.DeviceTester.Infrastructure.Factories;
using Tion.MagicAirTester.Commands;
using Tion.MagicAirTester.Contracts;
using Tion.MagicAirTester.Infrastructure;
using Tion.MagicAirTester.Infrastructure.Factories;
using Tion.MagicAirTester.MagicAirBS310;
using Tion.MagicAirTester.Tester;

namespace Tion.MagicAirTester.Forms
{
    public partial class FormMain : Form
    {
        private readonly ExecutorsFactory _executorsFactory;
        private readonly IOutputService _outputService;
        private readonly ILiveParser _liveParser;
        private IBreezerState _breezer3SState = new Breezer3SState();
        private IMagicAirState _magicAirBS310State = new MagicAirBS310State();
        private CommandExecutor<Bs310Command> _commandExecutor;
        private bool _testPassed;

        public FormMain(FormFactory formFactory, ExecutorsFactory executorsFactory, IOutputService outputService, ILiveParser liveParser)
        {
            _executorsFactory = executorsFactory;
            _outputService = outputService;
            _liveParser = liveParser;
            InitializeComponent();
            InitializeControls();
        }

        private void ResetFormState()
        {
            this.button_connectBreezer.Enabled = false;
            this.groupBox_breezerControls.Enabled = false;
            _outputService.Clear();
        }

        private void InitializeNewMagicAirDevice()
        {
            ResetFormState();

            _magicAirBS310State.ClearState();
            _breezer3SState.ClearState();
            _testPassed = false;

            _commandExecutor = _executorsFactory.CreateBs310Tester(_breezer3SState);

            _commandExecutor.MagicAirDataReceived += OnLiveDataReceivedStarted;
            _commandExecutor.MagicAirFound += OnMagicAirFound;
            _commandExecutor.TestFinished += CommandExecutorOnTestFinished;
        }

        private void CommandExecutorOnTestFinished(object sender, TestFinishedArgs testFinishedArgs)
        {
        }

        private void OnMagicAirFound(object sender, EventArgs eventArgs)
        {
            this.InvokeIfRequired(control =>
            {
                _magicAirBS310State.isFound = true;

                this.button_connectBreezer.Enabled = true;

                _commandExecutor.ExecuteSingleCommand(
                    new Bs310Command(0, "logenable", 1000, new BS310CommandResult(DeviceCommandType.Logenable, "")));
            });
        }

        private void OnLiveDataReceivedStarted(object o, MagicAirDataReceivedArgs magicAirDataReceivedArgs)
        {
            this.InvokeIfRequired(control =>
            {
                // breezer connecting state parsing
                var isBreezerConnected = _liveParser.Parse(magicAirDataReceivedArgs.Report).IsConnected;
                if (isBreezerConnected)
                {
                    if (!_breezer3SState.IsConnected)
                    {
                        _outputService.Log(LogType.Info, $"Breezer connected");
                    }
                    this.groupBox_breezerControls.Enabled = true;
                    this.button_connectBreezer.Enabled = false;
                    _breezer3SState.IsConnected = true;
                }

                // breezer speed parsing
                var currentSpeed = _liveParser.Parse(magicAirDataReceivedArgs.Report).Speed;
                if (currentSpeed > 0 && _breezer3SState.Speed != currentSpeed)
                {
                    _breezer3SState.Speed = currentSpeed;
                    _outputService.Log(LogType.Info, $"The speed was changed to {currentSpeed}");
                }

                //run tests
                if (_breezer3SState.IsConnected && _breezer3SState.Speed > 0 && this.checkBox_autotest.Checked && !_testPassed)
                {
                    _testPassed = true;
                    _commandExecutor.StartTest();
                }
            });
        }

        private void button_magicAirFind_Click(object sender, EventArgs e)
        {
            InitializeNewMagicAirDevice();
            _commandExecutor.Start((logType, message) =>
            {
                this.InvokeIfRequired(control =>
                {
                    _outputService.Log(logType, message);
                });
            });
        }

        private void groupBox_testingIndicators_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox_autotest_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBox_breezerControls.Enabled = !this.checkBox_autotest.Checked && _breezer3SState.IsConnected;
            var msg = this.checkBox_autotest.Checked ? "Program in automatic mode" : "Program in manual mode";
            _outputService.Log(LogType.Info, msg);
        }

        private void InitializeControls()
        {
            _outputService.Log(LogType.Info, "Program started");
            checkBox_autotest_CheckedChanged(null, null);
            output.DataBindings.Add("Text", _outputService, "Data", true, DataSourceUpdateMode.OnPropertyChanged);
            breezerSpeedValue.DataBindings.Add("Text", _breezer3SState, "Speed", true, DataSourceUpdateMode.OnPropertyChanged);
            breezerIsConnectedValue.DataBindings.Add("Text", _breezer3SState, "IsConnected", true, DataSourceUpdateMode.OnPropertyChanged);

            //breezerSpeedValue.DataBindings.Add("Text", _magicAirBS310State, "isFound", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void output_TextChanged(object sender, EventArgs e)
        {
            ScrollToCaret();
        }

        private void ScrollToCaret()
        {
            output.SelectionStart = output.Text.Length;
            output.ScrollToCaret();
        }

        private void button_breezerSpeedUp_Click(object sender, EventArgs e)
        {
            ChangeSpeed(true);
        }

        private void button_connectBreezer_Click(object sender, EventArgs e)
        {
            _commandExecutor.ExecuteSingleCommand(new Bs310Command(1, "pairing 0 1", 1000, new BS310CommandResult(DeviceCommandType.PairingWithBreezer3S, "6")));
        }

        private void button_unpairBreezer_Click(object sender, EventArgs e)
        {
            this.groupBox_breezerControls.Enabled = false;
            
            _commandExecutor.ExecuteSingleCommand(
                new Bs310Command(1, "deldev 1", 2000, new BS310CommandResult(DeviceCommandType.PairingWithBreezer3S, "6")),
                () =>
                {
                    this.InvokeIfRequired(c =>
                    {
                        this.button_connectBreezer.Enabled = true;
                        _outputService.Log(LogType.Info, "Breezer deleted");
                        _breezer3SState.ClearState();
                    });
                });
        }

        private void button_breezerSpeedDown_Click(object sender, EventArgs e)
        {
            ChangeSpeed(false);
        }

        private void ChangeSpeed(bool speedUp)
        {
            var stringCommand = speedUp ? "upvent 1" : "dwnvent 1";
            var prevSpeed = _breezer3SState.Speed;
            _commandExecutor.ExecuteSingleCommand(
                new Bs310Command(0, stringCommand, 2000, new BS310CommandResult(DeviceCommandType.Speed, "0")),
                () =>
                {
                    var msg = prevSpeed != _breezer3SState.Speed
                        ? $"Speed changed to {_breezer3SState.Speed}"
                        : "Speed not changed";
                    this.InvokeIfRequired(control =>
                    {
                        _outputService.Log(LogType.Info, msg);
                    });
                });
        }
    }
}
