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

namespace Tion.MagicAirTester.Forms
{
    public partial class FormMain : Form
    {
        private readonly IOutputService _outputService;
        private IBreezerState _breezerState = new BreezerState();

        public FormMain(FormFactory formFactory, TestersFactory testersFactory, IOutputService outputService, ILiveParser liveParser)
        {
            _outputService = outputService;
            InitializeComponent();
            InitializeControls();
            CommandExecutor<Bs310Command> commandExecutor = testersFactory.CreateBs310Tester();
            commandExecutor.DeviceDataReceived += (sender, args) =>
            {
                this.InvokeIfRequired(control =>
                {
                    _breezerState.Speed = liveParser.Parse(args.Report).Speed;
                });
            };

            commandExecutor.StartAutotest((logType, message) =>
            {
                this.InvokeIfRequired(control =>
                {
                    _outputService.Log(logType, message);
                });
            });
            


        }

        private void button_magicAirFind_Click(object sender, EventArgs e)
        {
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
            _outputService.Log(LogType.Info, "Initializing...");
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
    }
}
