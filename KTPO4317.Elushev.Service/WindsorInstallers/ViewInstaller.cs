using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using KTPO4317.Elushev.Lib.src.LogAn;
using KTPO4317.Elushev.Service.src.Views;

namespace KTPO4317.Elushev.Service.src.WindsorInstallers
{
    public class ViewInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store) 
        {
            container.Register(
                Component.For<IView>().ImplementedBy<ConsoleView>().LifeStyle.Transient);
        }
    }
}
