using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;

namespace BackOffice.Module.Pms.Views
{
    public partial class PayformsView : UserControl
    {
        public event EventHandler CloseMe;

        public PayformsView()
        {
            GoBackCommand = new DelegateCommand(() => GoBack());
            AddNewPayformCommand = new DelegateCommand(() => AddNewPayform());
            EditPayformCommand = new DelegateCommand(() => EditPayform());

            InitializeComponent();

            _editorView.CloseMe += CloseView;
        }

        public ICommand GoBackCommand { get; private set; }

        private void GoBack()
        {
            CloseMe?.Invoke(this, EventArgs.Empty);
        }

        public ICommand AddNewPayformCommand { get; private set; }

        private void AddNewPayform()
        {
            _editorView.Visibility =  Visibility.Visible;
            _listView.Visibility = Visibility.Hidden;
        }

        public ICommand EditPayformCommand { get; private set; }

        private void EditPayform()
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

