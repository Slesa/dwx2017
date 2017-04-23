using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using BackOffice.Helpers;
using BackOffice.Models;

namespace BackOffice.Views
{
    /// <summary>
    /// Interaction logic for PmsModulesView.xaml
    /// </summary>
    public partial class PmsModulesView : UserControl
    {
        public PmsModulesView()
        {
            InitializeComponent();
            _discountsView.CloseMe += CloseView;
            _payformsView.CloseMe += CloseView;
            _salesItemsView.CloseMe += CloseView;
            _salesFamiliesView.CloseMe += CloseView;
            _salesFamilyGroupsView.CloseMe += CloseView;
        }

        public event EventHandler CloseMe;

        ObservableCollection<OfficeModule> _pmsModulesCollection;
        public ObservableCollection<OfficeModule> PmsModulesCollection
        {
            get
            {
                if (_pmsModulesCollection == null)
                {
                    _pmsModulesCollection = new ObservableCollection<OfficeModule>();
                    foreach (var module in CreatePmsModulesCollection())
                        _pmsModulesCollection.Add(module);
                }
                return _pmsModulesCollection;
            }
        }


        private IEnumerable<OfficeModule> CreatePmsModulesCollection()
        {
            yield return
                new OfficeModule()
                {
                    Title = "Back",
                    Tooltip = "Back to module selection",
                    //IconFileName = IconResources.BackIcon,
                    Command = new DelegateCommand(_ => BackToModules())
                };
            yield return
                new OfficeModule()
                {
                    Title = "Discounts",
                    Tooltip = "Manage discounts",
                    //IconFileName = IconResources.DiscountIcon,
                    Command = new DelegateCommand(_ => ShowDiscountsView())
                };
            yield return
                new OfficeModule()
                {
                    Title = "Payforms",
                    Tooltip = "Manage payforms",
                    //IconFileName = IconResources.UserRoleIcon,
                    Command = new DelegateCommand(_ => ShowPayformsView())
                };
            yield return
                new OfficeModule()
                {
                    Title = "Sales Items",
                    Tooltip = "Manage sales items",
                    //IconFileName = IconResources.UserRoleIcon,
                    Command = new DelegateCommand(_ => ShowSalesItemsView())
                };
            yield return
                new OfficeModule()
                {
                    Title = "Sales Families",
                    Tooltip = "Manage sales families",
                    //IconFileName = IconResources.UserRoleIcon,
                    Command = new DelegateCommand(_ => ShowSalesFamiliesView())
                };
            yield return
                new OfficeModule()
                {
                    Title = "Sales Family Groups",
                    Tooltip = "Manage sales family groups",
                    //IconFileName = IconResources.UserRoleIcon,
                    Command = new DelegateCommand(_ => ShowSalesFamilyGroupsView())
                };
        }


        private void CloseView(object sender, EventArgs e)
        {
            var view = sender as UserControl;
            view.Visibility = Visibility.Hidden;
            _selectionView.Visibility = Visibility.Visible;
            _selectionView.SelectedItem = null;
        }

        private void ShowDiscountsView()
        {
            _discountsView.Visibility = Visibility.Visible;
            _selectionView.Visibility = Visibility.Hidden;
        }

        private void ShowPayformsView()
        {
            _payformsView.Visibility = Visibility.Visible;
            _selectionView.Visibility = Visibility.Hidden;
        }

        private void ShowSalesItemsView()
        {
            _salesItemsView.Visibility = Visibility.Visible;
            _selectionView.Visibility = Visibility.Hidden;
        }

        private void ShowSalesFamiliesView()
        {
            _salesFamiliesView.Visibility = Visibility.Visible;
            _selectionView.Visibility = Visibility.Hidden;
        }

        private void ShowSalesFamilyGroupsView()
        {
            _salesFamilyGroupsView.Visibility = Visibility.Visible;
            _selectionView.Visibility = Visibility.Hidden;
        }

        private void BackToModules()
        {
            _selectionView.SelectedItem = null;
            CloseMe?.Invoke(this, EventArgs.Empty);
        }

        private void _selectionView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listbox = sender as ListBox;
            var module = listbox?.SelectedItem as OfficeModule;
            module?.Command.Execute(null);
        }
    }
}
