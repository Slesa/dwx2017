using BackOffice.Common;
using BackOffice.Module.Ums.Modules;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;

namespace BackOffice.Module.Ums
{
    public class UmsPrismModule : IModule
    {
        readonly IUnityContainer _container;

        public UmsPrismModule(IUnityContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {
            _container.RegisterType<IOfficeModule, UmsOfficeModule>(UmsOfficeModule.Name, new ContainerControlledLifetimeManager());
        }
    }
}