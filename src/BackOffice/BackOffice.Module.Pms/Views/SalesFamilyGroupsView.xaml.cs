using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;

namespace BackOffice.Module.Pms.Views
{
    public partial class SalesFamilyGroupsView : UserControl
    {
        public event EventHandler CloseMe;

        public SalesFamilyGroupsView()
        {
            GoBackCommand = new DelegateCommand(() => GoBack());
            AddNewSalesFamilyGroupCommand = new DelegateCommand(() => AddNewSalesFamilyGroup());
            EditSalesFamilyGroupCommand = new DelegateCommand(() => EditSalesFamilyGroup());

            InitializeComponent();

            _editorView.CloseMe += CloseView;
        }

        public ICommand GoBackCommand { get; private set; }

        private void GoBack()
        {
            CloseMe?.Invoke(this, EventArgs.Empty);
        }

        public ICommand AddNewSalesFamilyGroupCommand { get; private set; }

        private void AddNewSalesFamilyGroup()
        {
            _editorView.Visibility =  Visibility.Visible;
            _listView.Visibility = Visibility.Hidden;
        }

        public ICommand EditSalesFamilyGroupCommand { get; private set; }

        private void EditSalesFamilyGroup()
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

