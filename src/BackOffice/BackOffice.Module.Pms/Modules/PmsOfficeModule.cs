using System;
using System.Windows.Controls;
using BackOffice.Common;
using BackOffice.Common.Models;
using BackOffice.Common.Resources;
using Microsoft.Practices.Prism.Logging;

namespace BackOffice.Module.Pms.Modules
{
    public class PmsOfficeModule : OfficeModule
    {
        public static readonly string Name = "PmsModulesView";

        public PmsOfficeModule()
        {
            Title = "POS Management";
            Tooltip = "Manage articles, families, payforms and discounts";
            IconFile = IconResources.PmsIcon;
            //Priority = 11;
            //Keywords = Strings.PmsOfficeModule_Keywords.Split(',');
            //TargetUri = new Uri(PmsViews.PmsModuleView, UriKind.Relative);
        }
    }
}