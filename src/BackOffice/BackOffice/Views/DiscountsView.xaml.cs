﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BackOffice.Helpers;

namespace BackOffice.Views
{
    public partial class DiscountsView : UserControl
    {
        public event EventHandler CloseMe;

        public DiscountsView()
        {
            GoBackCommand = new DelegateCommand(_ => GoBack());
            AddNewDiscountCommand = new DelegateCommand(_ => AddNewDiscount());
            EditDiscountCommand = new DelegateCommand(_ => EditDiscount());

            InitializeComponent();

            _editorView.CloseMe += CloseView;
        }

        public ICommand GoBackCommand { get; private set; }

        private void GoBack()
        {
            CloseMe?.Invoke(this, EventArgs.Empty);
        }

        public ICommand AddNewDiscountCommand { get; private set; }

        private void AddNewDiscount()
        {
            _editorView.Visibility =  Visibility.Visible;
            _listView.Visibility = Visibility.Hidden;
        }

        public ICommand EditDiscountCommand { get; private set; }

        private void EditDiscount()
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

