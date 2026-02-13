using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace InvestInfo.ViewModel
{
    public class NavigationVM : Utilities.ViewModelBase
    {
        private readonly IServiceProvider _serviceProvider;
        private object? _currentView;
        public object? CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ICommand HomeCommand { get; set; }
        public ICommand OperationsCommand { get; set; }
        public ICommand CloseApp { get; set; }

        private void Home(object? obj) => CurrentView = _serviceProvider.GetRequiredService<HomeVM>();
        private void Operations(object? obj) => CurrentView = _serviceProvider.GetRequiredService<OperationsVM>();

        public NavigationVM(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            HomeCommand = new Utilities.RelayCommand(Home);
            OperationsCommand = new Utilities.RelayCommand(Operations);
            CloseApp = new Utilities.RelayCommand(obj => System.Windows.Application.Current.Shutdown());

            // Set default view
            CurrentView = _serviceProvider.GetRequiredService<HomeVM>();
        }
    }
}
