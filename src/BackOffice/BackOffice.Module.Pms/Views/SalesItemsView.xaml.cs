using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;

namespace BackOffice.Module.Pms.Views
{
    public partial class SalesItemsView : UserControl
    {
        public event EventHandler CloseMe;

        public SalesItemsView()
        {
            GoBackCommand = new DelegateCommand(() => GoBack());
            AddNewSalesItemCommand = new DelegateCommand(() => AddNewSalesItem());
            EditSalesItemCommand = new DelegateCommand(() => EditSalesItem());

            InitializeComponent();

            _editorView.CloseMe += CloseView;
        }

        public ICommand GoBackCommand { get; private set; }

        private void GoBack()
        {
            CloseMe?.Invoke(this, EventArgs.Empty);
        }

        public ICommand AddNewSalesItemCommand { get; private set; }

        private void AddNewSalesItem()
        {
            _editorView.Visibility =  Visibility.Visible;
            _listView.Visibility = Visibility.Hidden;
        }

        public ICommand EditSalesItemCommand { get; private set; }

        private void EditSalesItem()
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

