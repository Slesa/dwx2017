using BackOffice.Common;
using BackOffice.Module.Pms.Modules;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;

namespace BackOffice.Module.Pms
{
    public class PmsPrismModule : IModule
    {
        readonly IUnityContainer _container;

        public PmsPrismModule(IUnityContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {
            _container.RegisterType<IOfficeModule, PmsOfficeModule>(PmsOfficeModule.Name, new ContainerControlledLifetimeManager());
        }
    }
}