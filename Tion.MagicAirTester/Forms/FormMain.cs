using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tion.DeviceTester.Infrastructure.Factories;

namespace Tion.MagicAirTester.Forms
{
    public partial class FormMain : Form
    {
        public FormMain(FormFactory formFactory)
        {
            InitializeComponent();
        }
    }
}
