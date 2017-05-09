using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using BackOffice.Common.Models;
using BackOffice.Common.Resources;
using Microsoft.Practices.Prism.Commands;

namespace BackOffice.Views
{
    public partial class ModulesView : UserControl
    {
        public ModulesView()
        {
            InitializeComponent();
            _umsView.CloseMe += CloseView;
            _pmsView.CloseMe += CloseView;
        }

        ObservableCollection<OfficeModule> _modulesCollection;
        public ObservableCollection<OfficeModule> ModulesCollection
        {
            get
            {
                if (_modulesCollection == null)
                {
                    _modulesCollection = new ObservableCollection<OfficeModule>();
                    foreach (var module in CreateModulesCollection())
                        _modulesCollection.Add(module);
                }
                return _modulesCollection;
            }
        }

        private IEnumerable<OfficeModule> CreateModulesCollection()
        {
            yield return
                new OfficeModule()
                {
                    Title = "User Management",
                    Tooltip = "Manage users of the system, edit their profiles and their rights",
                    IconFile = IconResources.UmsIcon,
                    Command = new DelegateCommand(() => ShowUmsView())
                };
            yield return
                new OfficeModule()
                {
                    Title = "POS Management",
                    Tooltip = "Manage articles, families, payforms and discounts",
                    IconFile = IconResources.PmsIcon,
                    Command = new DelegateCommand(() => ShowPmsView())
                };
        }

        private void CloseView(object sender, EventArgs e)
        {
            var view = sender as UserControl;
            view.Visibility = Visibility.Hidden;
            _selectionView.Visibility = Visibility.Visible;
            _selectionView.SelectedItem = null;
        }

        private void ShowUmsView()
        {
            _umsView.Visibility = Visibility.Visible;
            _selectionView.Visibility = Visibility.Hidden;
        }

        private void ShowPmsView()
        {
            _pmsView.Visibility = Visibility.Visible;
            _selectionView.Visibility = Visibility.Hidden;
        }

        private void _selectionView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listbox = sender as ListBox;
            var module = listbox?.SelectedItem as OfficeModule;
            module?.Command.Execute(null);
        }
    }
}
