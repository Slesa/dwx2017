using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using BackOffice.Helpers;
using BackOffice.Models;
using BackOffice.Resources;

namespace BackOffice.Views
{
    public partial class ModulesView : UserControl
    {
        public ModulesView()
        {
            InitializeComponent();
            _umsView.CloseMe += CloseView;
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
                    IconFileName = IconResources.UmsIcon,
                    Command = new DelegateCommand(_ => ShowUmsView())
                };
            yield return
                new OfficeModule()
                {
                    Title = "POS Management",
                    Tooltip = "Manage articles, families, payforms and discounts",
                    IconFileName = IconResources.PmsIcon,
                    Command = new DelegateCommand(_ => ShowPmsView())
                };
        }

        private void CloseView(object sender, EventArgs e)
        {
            var view = sender as UserControl;
            view.Visibility = Visibility.Hidden;
            _selectionView.Visibility = Visibility.Visible;
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
    }
}
