using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;
using log4net;
using log4net.Repository.Hierarchy;
using Tion.DeviceTester;
using Tion.DeviceTester.Infrastructure.Factories;

namespace Tion.MagicAirTester
{
    static class Program
    {
        private static IContainer _container;
        private static ILog Logger { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Logger = LogManager.GetLogger(Assembly.GetExecutingAssembly(), "Application");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            _container = Bootstrapper.Initialize();

            var formFactory = _container.Resolve<FormFactory>();
            Application.Run(formFactory.CreateMainForm());
        }
    }
}
