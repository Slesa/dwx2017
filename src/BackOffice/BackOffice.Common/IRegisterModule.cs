using Microsoft.Practices.Prism.Modularity;

namespace BackOffice.Common
{
    public interface IRegisterModule
    {
        ModuleInfo GetModuleInfo();
    }
}