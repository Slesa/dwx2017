﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BackOffice.Module.Ums.Data;
using BackOffice.Module.Ums.Models;
using Microsoft.Practices.Prism.Commands;

namespace BackOffice.Module.Ums.Views
{
    public partial class UsersView : UserControl
    {
        public event EventHandler CloseMe;

        public UsersView()
        {
            BackToUsersCommand = new DelegateCommand(() => BackToUsers());
            AddNewUserCommand = new DelegateCommand(() => AddNewUser());
            EditUserCommand = new DelegateCommand(() => EditUser());

            Users = new ObservableCollection<User>();

            InitializeComponent();

            _editorView.CloseMe += CloseView;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                foreach (var user in UserData.ReadUsers())
                {
                    Users.Add(user);
                }
            }
        }

        public ObservableCollection<User> Users { get; private set; }

        public ICommand BackToUsersCommand { get; private set; }

        private void BackToUsers()
        {
            CloseMe?.Invoke(this, EventArgs.Empty);
        }

        public ICommand AddNewUserCommand { get; private set; }

        private void AddNewUser()
        {
            _editorView.Visibility = Visibility.Visible;
            _listView.Visibility = Visibility.Hidden;
        }

        public ICommand EditUserCommand { get; private set; }

        private void EditUser()
        {
            _editorView.Visibility = Visibility.Visible;
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
