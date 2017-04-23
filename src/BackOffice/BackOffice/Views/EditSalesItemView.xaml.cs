﻿using System;
using System.Windows.Controls;
using System.Windows.Input;
using BackOffice.Helpers;

namespace BackOffice.Views
{
    public partial class EditSalesItemView : UserControl
    {
        public EditSalesItemView()
        {
            GoBackCommand = new DelegateCommand(_ => GoBack());
            InitializeComponent();
        }

        public event EventHandler CloseMe;

        public ICommand GoBackCommand { get; private set; }

        private void GoBack()
        {
            CloseMe?.Invoke(this, EventArgs.Empty);
        }
    }
}
