using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using KTPO4317.Elushev.Lib.src.SampleCommands;

namespace KTPO4317.Elushev.Service.src.WindsorInstallers
{
    public class SampleCommandInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<ISampleCommand>().ImplementedBy<ExceptionIntercepter>().LifeStyle.Singleton,
                Component.For<ISampleCommand>().ImplementedBy<SampleCommandDecorator>().LifeStyle.Singleton,
                Component.For<ISampleCommand>().ImplementedBy<SecondCommand>().LifeStyle.Singleton
                );
        }
    }
}
