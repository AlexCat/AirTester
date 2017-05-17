using System.Reflection;
using Autofac;
using Tion.DeviceTester.Infrastructure.Factories;
using Tion.MagicAirTester.Contracts;
using Tion.MagicAirTester.Infrastructure.Factories;
using Tion.MagicAirTester.Infrastructure.Services;
using Tion.MagicAirTester.MagicAirBS310;

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
            builder.RegisterType<ExecutorsFactory>().AsSelf().SingleInstance();
            builder.RegisterType<BS310DeviceFinder>().As<IDeviceFinder>();
            builder.RegisterType<LiveBS310Parser>().As<ILiveParser>();

            return builder.Build();
        }
    }
}
