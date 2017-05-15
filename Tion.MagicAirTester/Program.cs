using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;
using Tion.DeviceTester;
using Tion.DeviceTester.Infrastructure.Factories;

namespace Tion.MagicAirTester
{
    static class Program
    {
        private static IContainer _container;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            _container = Bootstrapper.Initialize();

            var formFactory = _container.Resolve<FormFactory>();
            Application.Run(formFactory.CreateMainForm());
        }
    }
}
