﻿using BackOffice.Common;
using Microsoft.Practices.Prism.Modularity;

namespace BackOffice.Module.Ums
{
    public class RegisterUmsModule : IRegisterModule
    {
        public ModuleInfo GetModuleInfo()
        {
            var umsModule = typeof(UmsPrismModule);
            return new ModuleInfo
            {
                ModuleName = umsModule.Name,
                ModuleType = umsModule.AssemblyQualifiedName
            };
        }
    }
}