using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BackOffice.Data;
using BackOffice.Models;
using Microsoft.Practices.Prism.Commands;

namespace BackOffice.Views
{
    public partial class UserRolesView : UserControl
    {
        public event EventHandler CloseMe;

        public UserRolesView()
        {
            BackToUsersCommand = new DelegateCommand(() => BackToUsers());
            AddNewUserRoleCommand = new DelegateCommand(() => AddNewUserRole());
            EditUserRoleCommand = new DelegateCommand(() => EditUserRole());

            UserRoles = new ObservableCollection<UserRole>();

            InitializeComponent();

            _editorView.CloseMe += CloseView;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                foreach (var userRole in UserRoleData.ReadUserRoles())
                {
                    UserRoles.Add(userRole);
                }
            }
        }

        public ObservableCollection<UserRole> UserRoles { get; private set; }

        public ICommand BackToUsersCommand { get; private set; }

        private void BackToUsers()
        {
            CloseMe?.Invoke(this, EventArgs.Empty);
        }

        public ICommand AddNewUserRoleCommand { get; private set; }

        private void AddNewUserRole()
        {
            _editorView.Visibility =  Visibility.Visible;
            _listView.Visibility = Visibility.Hidden;
        }

        public ICommand EditUserRoleCommand { get; private set; }

        private void EditUserRole()
        {
            _editorView.Visibility =  Visibility.Visible;
            _listView.Visibility = Visibility.Hidden;
        }

        private void CloseView(object sender, EventArgs e)
        {
            var view = sender as UserControl;
            view.Visibility = Visibility.Hidden;
            _listView.Visibility = Visibility.Visible;
        }

    }
}

