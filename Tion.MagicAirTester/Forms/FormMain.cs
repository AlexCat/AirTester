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
using Tion.MagicAirTester.Infrastructure.Factories;
using Tion.MagicAirTester.Tester;

namespace Tion.MagicAirTester.Forms
{
    public partial class FormMain : Form
    {
        public FormMain(FormFactory formFactory, TestersFactory testersFactory)
        {
            InitializeComponent();
            InitializeControls();
            CommandExecutor<Bs310Command> commandExecutor = testersFactory.CreateBs310Tester();
            if (this.checkBox_autotest.Checked)
            {
                commandExecutor.StartAutotest();
            }
            
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
            checkBox_autotest_CheckedChanged(null, null);
        }
    }
}
