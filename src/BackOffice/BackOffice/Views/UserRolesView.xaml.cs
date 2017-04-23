﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BackOffice.Helpers;

namespace BackOffice.Views
{
    public partial class UserRolesView : UserControl
    {
        public event EventHandler CloseMe;

        public UserRolesView()
        {
            BackToUsersCommand = new DelegateCommand(_ => BackToUsers());
            AddNewUserRoleCommand = new DelegateCommand(_ => AddNewUserRole());
            EditUserRoleCommand = new DelegateCommand(_ => EditUserRole());

            InitializeComponent();

            _editorView.CloseMe += CloseView;
        }

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

