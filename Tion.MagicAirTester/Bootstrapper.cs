using System.Reflection;
using Autofac;
using Tion.DeviceTester.Infrastructure.Factories;
using Tion.MagicAirTester.Contracts;
using Tion.MagicAirTester.DeviceFinder;
using Tion.MagicAirTester.Infrastructure.Factories;
using Tion.MagicAirTester.Infrastructure.Services;

namespace Tion.MagicAirTester {

    /// <summary>
    /// SimpleInjector container initialization
    /// </summary>
    public static class Bootstrapper {
        public static IContainer Initialize() {
            var builder = new ContainerBuilder();

            var logger = log4net.LogManager.GetLogger(Assembly.GetExecutingAssembly(), "Logger");
            builder.Register(x => logger).SingleInstance();
            builder.RegisterType<OutputService>().As<IOutputService>().SingleInstance();
            //builder.RegisterType<FormAbout>().AsSelf().SingleInstance();
            builder.RegisterType<FormFactory>().AsSelf().SingleInstance();
            builder.RegisterType<DeviceFinderFactory>().AsSelf().SingleInstance();
            builder.RegisterType<TestersFactory>().AsSelf().SingleInstance();
            builder.RegisterType<BS310DeviceFinder>().As<IDeviceFinder>();

            return builder.Build();
        }
    }
}
