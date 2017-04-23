using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using BackOffice.Helpers;
using BackOffice.Models;

namespace BackOffice.Views
{
    public partial class UmsModulesView : UserControl
    {
        public UmsModulesView()
        {
            InitializeComponent();
            _usersView.CloseMe += CloseView;
            _userRolesView.CloseMe += CloseView;
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
                    //IconFileName = IconResources.BackIcon,
                    Command = new DelegateCommand(_ => BackToModules())
                };
            yield return
                new OfficeModule()
                {
                    Title = "Users",
                    Tooltip = "Manage users and their rights",
                    //IconFileName = IconResources.UserIcon,
                    Command = new DelegateCommand(_ => ShowUsersView())
                };
            yield return
                new OfficeModule()
                {
                    Title = "User roles",
                    Tooltip = "Manage user roles",
                    //IconFileName = IconResources.UserRoleIcon,
                    Command = new DelegateCommand(_ => ShowUserRolesView())
                };
        }

        private void CloseView(object sender, EventArgs e)
        {
            var view = sender as UserControl;
            view.Visibility = Visibility.Hidden;
            _selectionView.Visibility = Visibility.Visible;
            _selectionView.SelectedItem = null;
        }

        private void BackToModules()
        {
            _selectionView.SelectedItem = null;
            CloseMe?.Invoke(this, EventArgs.Empty);
        }

        private void ShowUsersView()
        {
            _usersView.Visibility = Visibility.Visible;
            _selectionView.Visibility = Visibility.Hidden;
        }

        private void ShowUserRolesView()
        {
            _userRolesView.Visibility = Visibility.Visible;
            _selectionView.Visibility = Visibility.Hidden;
        }

        private void _selectionView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listbox = sender as ListBox;
            var module = listbox?.SelectedItem as OfficeModule;
            module?.Command.Execute(null);
        }
    }
}
