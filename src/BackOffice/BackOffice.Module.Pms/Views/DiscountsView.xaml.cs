using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BackOffice.Module.Pms.Data;
using BackOffice.Module.Pms.Model;
using Microsoft.Practices.Prism.Commands;

namespace BackOffice.Module.Pms.Views
{
    public partial class DiscountsView : UserControl
    {
        public event EventHandler CloseMe;

        public DiscountsView()
        {
            GoBackCommand = new DelegateCommand(GoBack);
            AddNewDiscountCommand = new DelegateCommand(AddNewDiscount);
            EditDiscountCommand = new DelegateCommand(EditDiscount);

            Discounts = new ObservableCollection<Discount>();

            InitializeComponent();

            _editorView.CloseMe += CloseView;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                foreach (var discount in DiscountData.ReadDiscounts())
                {
                    Discounts.Add(discount);
                }
            }
        }

        public ObservableCollection<Discount> Discounts { get; private set; }

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

