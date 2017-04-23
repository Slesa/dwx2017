﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BackOffice.Helpers;

namespace BackOffice.Views
{
    public partial class SalesFamiliesView : UserControl
    {
        public event EventHandler CloseMe;

        public SalesFamiliesView()
        {
            GoBackCommand = new DelegateCommand(_ => GoBack());
            AddNewSalesFamilyCommand = new DelegateCommand(_ => AddNewSalesFamily());
            EditSalesFamilyCommand = new DelegateCommand(_ => EditSalesFamily());

            InitializeComponent();

            _editorView.CloseMe += CloseView;
        }

        public ICommand GoBackCommand { get; private set; }

        private void GoBack()
        {
            CloseMe?.Invoke(this, EventArgs.Empty);
        }

        public ICommand AddNewSalesFamilyCommand { get; private set; }

        private void AddNewSalesFamily()
        {
            _editorView.Visibility =  Visibility.Visible;
            _listView.Visibility = Visibility.Hidden;
        }

        public ICommand EditSalesFamilyCommand { get; private set; }

        private void EditSalesFamily()
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
