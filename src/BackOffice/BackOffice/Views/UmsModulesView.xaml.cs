using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using BackOffice.Helpers;
using BackOffice.Models;
using BackOffice.Resources;

namespace BackOffice.Views
{
    public partial class UmsModulesView : UserControl
    {
        public UmsModulesView()
        {
            InitializeComponent();
        }

        public event EventHandler CloseMe;

        ObservableCollection<OfficeModule> _umsModulesCollection;
        public ObservableCollection<OfficeModule> UmsModulesCollection
        {
            get
            {
                if (_umsModulesCollection == null)
                {
                    _umsModulesCollection = new ObservableCollection<OfficeModule>();
                    foreach (var module in CreateUmsModulesCollection())
                        _umsModulesCollection.Add(module);
                }
                return _umsModulesCollection;
            }
        }


        private IEnumerable<OfficeModule> CreateUmsModulesCollection()
        {
            yield return
                new OfficeModule()
                {
                    Title = "Back",
                    Tooltip = "Back to module selection",
                    IconFileName = IconResources.BackIcon,
                    Command = new DelegateCommand(_ => BackToModules())
                };
            yield return
                new OfficeModule()
                {
                    Title = "Users",
                    Tooltip = "Manage users and their rights",
                    IconFileName = IconResources.UserIcon,
                    Command = new DelegateCommand(_ => ShowUsersView())
                };
            yield return
                new OfficeModule()
                {
                    Title = "User roles",
                    Tooltip = "Manage user roles",
                    IconFileName = IconResources.UserRoleIcon,
                    Command = new DelegateCommand(_ => ShowUserRolesView())
                };
        }

        private void BackToModules()
        {
            CloseMe?.Invoke(this, EventArgs.Empty);
        }

        private void ShowUsersView()
        {
            //_umsView.Visibility = Visibility.Visible;
            _selectionView.Visibility = Visibility.Hidden;
        }

        private void ShowUserRolesView()
        {
            //_pmsView.Visibility = Visibility.Visible;
            _selectionView.Visibility = Visibility.Hidden;
        }
    }
}
