using System;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;

namespace BackOffice.Views
{
    public partial class EditSalesFamilyView : UserControl
    {
        public EditSalesFamilyView()
        {
            GoBackCommand = new DelegateCommand(() => GoBack());
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
