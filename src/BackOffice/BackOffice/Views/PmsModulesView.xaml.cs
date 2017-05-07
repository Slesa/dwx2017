using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using BackOffice.Models;
using BackOffice.Resources;
using Microsoft.Practices.Prism.Commands;

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
                    IconFile = IconResources.BackIcon,
                    Command = new DelegateCommand(() => BackToModules())
                };
            yield return
                new OfficeModule()
                {
                    Title = "Discounts",
                    Tooltip = "Manage discounts",
                    IconFile = IconResources.DiscountIcon,
                    Command = new DelegateCommand(() => ShowDiscountsView())
                };
            yield return
                new OfficeModule()
                {
                    Title = "Payforms",
                    Tooltip = "Manage payforms",
                    IconFile = IconResources.PayformIcon,
                    Command = new DelegateCommand(() => ShowPayformsView())
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
