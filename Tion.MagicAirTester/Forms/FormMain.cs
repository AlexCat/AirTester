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

            DeviceTester<Bs310Command> _deviceTester = testersFactory.CreateBs310Tester();
            _deviceTester.Run(true);
        }
    }
}
