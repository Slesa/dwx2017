using BackOffice.Common.Models;
using BackOffice.Common.Resources;

namespace BackOffice.Module.Ums.Modules
{
    public class UmsOfficeModule : OfficeModule
    {
        public static readonly string Name = "UmsModulesView";

        public UmsOfficeModule()
        {
            Title = "User Management";
            //Description = Strings.UserModule_Description;
            Tooltip = "Manage users of the system, edit their profiles and their rights";
            IconFile = IconResources.UmsIcon;
            //Priority = 1; 
            //Keywords = Strings.UmsOfficeModule_Keywords.Split(',');
            //TargetUri = new Uri(UmsViews.UmsModuleView, UriKind.Relative);
        }
    }
}