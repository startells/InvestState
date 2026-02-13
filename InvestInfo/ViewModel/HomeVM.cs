using System;
using System.Collections.Generic;
using System.Text;
using InvestInfo.Data;
using InvestInfo.Model;
using InvestInfo.Utilities;

namespace InvestInfo.ViewModel
{
    public class HomeVM : ViewModelBase
    {
        private readonly IOperationRepository _operationRepository;

        private decimal _portfolioSum;
        public decimal PortfolioSum
        {
            get => _portfolioSum;
            set { _portfolioSum = value; OnPropertyChanged(); }
        }

        public HomeVM(IOperationRepository operationRepository)
        {
            _operationRepository = operationRepository;
            _operationRepository.OperationsChanged += async (s, e) => await LoadPortfolioSumAsync();

            _ = LoadPortfolioSumAsync();
        }

        private async Task LoadPortfolioSumAsync()
        {
            var operations = await _operationRepository.GetAllAsync();
            PortfolioSum = operations.Sum(op => op.Amount);
        }
    }
}
