using InvestInfo.Base;
using InvestInfo.Interface;
using InvestInfo.Models;
using InvestInfo.Services;
using System.Collections.ObjectModel;

namespace InvestInfo.ViewModels
{
    public class OperationsViewModel : ViewModelBase
    {
        private readonly IOperationService _operationService;

        private Operation? _selectedOperation;
        private ObservableCollection<Operation> _operations;
        private bool _isLoading;

        public Operation? SelectedOperation
        {
            get => _selectedOperation;
            set => SetProperty(ref _selectedOperation, value);
        }

        public ObservableCollection<Operation> Operations
        {
            get => _operations;
            set => SetProperty(ref _operations, value);
        }

        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        public OperationsViewModel(IOperationService operationService)
        {
            _operationService = operationService;
            _operations = new ObservableCollection<Operation>();

            _ = LoadOperationsAsync();
        }

        public async Task LoadOperationAsync(int id)
        {
            try
            {
                SelectedOperation = await _operationService.GetOperationByIdAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка загрузки операции: {ex.Message}");
            }
        }

        public async Task LoadOperationsAsync()
        {
            try
            {
                IsLoading = true;
                var operations = await _operationService.GetAllOperationsAsync();

                Operations.Clear();
                foreach (var operation in operations)
                {
                    Operations.Add(operation);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка загрузки операций: {ex.Message}");
                Operations.Clear();
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}
