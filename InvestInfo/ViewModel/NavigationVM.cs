using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace InvestInfo.ViewModel
{
    class NavigationVM : Utilities.ViewModelBase
    {
        private object? _currentView;
        public object? CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ICommand HomeCommand { get; set; }
        public ICommand OperationsCommand { get; set; }
        public ICommand CloseApp { get; set; }

        private void Home(object? obj) => CurrentView = new HomeVM();
        private void Operations(object? obj) => CurrentView = new OperationsVM();

        public NavigationVM()
        {
            HomeCommand = new Utilities.RelayCommand(Home);
            OperationsCommand = new Utilities.RelayCommand(Operations);
            CloseApp = new Utilities.RelayCommand(obj => System.Windows.Application.Current.Shutdown());

            // Set default view
            CurrentView = new HomeVM();
        }
    }
}
