using BackOffice.Common;
using Microsoft.Practices.Prism.Modularity;

namespace BackOffice.Module.Pms
{
    public class RegisterPmsModule : IRegisterModule
    {
        public ModuleInfo GetModuleInfo()
        {
            var pmsModule = typeof(PmsPrismModule);
            return new ModuleInfo
            {
                ModuleName = pmsModule.Name,
                ModuleType = pmsModule.AssemblyQualifiedName
            };
        }
    }
}