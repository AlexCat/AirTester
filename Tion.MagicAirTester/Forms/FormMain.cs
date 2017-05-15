using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HidLibrary;
using Tion.DeviceTester.Infrastructure.Factories;
using Tion.MagicAirTester.Commands;
using Tion.MagicAirTester.Contracts;
using Tion.MagicAirTester.DeviceFinder;
using Tion.MagicAirTester.Infrastructure;
using Tion.MagicAirTester.Infrastructure.Factories;
using Tion.MagicAirTester.Tester;
using Timer = System.Timers.Timer;

namespace Tion.MagicAirTester.Forms
{
    public partial class FormMain : Form
    {
        private readonly TestersFactory _testersFactory;
        private readonly IOutputService _outputService;
        private readonly ILiveParser _liveParser;
        private IBreezerState _breezerState = new BreezerState();
        private CommandExecutor<Bs310Command> _commandExecutor;

        public FormMain(FormFactory formFactory, TestersFactory testersFactory, IOutputService outputService, ILiveParser liveParser)
        {
            _testersFactory = testersFactory;
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

        private void InitializeNewCommandExecutor()
        {
            ResetFormState();

            _commandExecutor = _testersFactory.CreateBs310Tester();
            _commandExecutor.DeviceDataReceived += OnDeviceConnected;
        }

        private void OnDeviceConnected(object o, DeviceFoundArgs deviceFoundArgs)
        {
            this.InvokeIfRequired(control =>
            {
                this.groupBox_breezerControls.Enabled = true;

                var currentSpeed = _liveParser.Parse(deviceFoundArgs.Report).Speed;
                if (currentSpeed > 0 && _breezerState.Speed != currentSpeed)
                {
                    _breezerState.Speed = currentSpeed;
                    _outputService.Log(LogType.Info, $"The speed was changed to {currentSpeed}");
                }

            });
        }

        private void button_magicAirFind_Click(object sender, EventArgs e)
        {
            InitializeNewCommandExecutor();
            if (this.checkBox_autotest.Checked)
            {
                _commandExecutor.StartAutotest((logType, message) =>
                {

                    this.InvokeIfRequired(control =>
                    {
                        this.button_connectBreezer.Enabled = true;
                        _outputService.Log(logType, message);
                    });
                });
            }
        }

        private void groupBox_testingIndicators_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox_autotest_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBox_breezerControls.Enabled = !this.checkBox_autotest.Checked;
        }

        private void InitializeControls()
        {
            _outputService.Log(LogType.Info, "Program started");
            checkBox_autotest_CheckedChanged(null, null);
            output.DataBindings.Add("Text", _outputService, "Data", true, DataSourceUpdateMode.OnPropertyChanged);
            breezerSpeedValue.DataBindings.Add("Text", _breezerState, "Speed", true, DataSourceUpdateMode.OnPropertyChanged);
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
            var prevSpeed = _breezerState.Speed;
            _commandExecutor.ExecuteSingleCommand(
                new Bs310Command(0, "upvent 1", 2000, new BS310CommandResult(Bs310CommandResultProperty.Speed, "0")),
                () =>
                {
                    var msg = prevSpeed != _breezerState.Speed
                        ? $"Speed changed to {_breezerState.Speed}"
                        : "Speed not changed";
                    this.InvokeIfRequired(control =>
                    {
                        _outputService.Log(LogType.Info, msg);
                    });
                });
        }
    }
}
