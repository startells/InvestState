using InvestInfo.Data;
using InvestInfo.Model;
using InvestInfo.Utilities;
using System.Collections.ObjectModel;

namespace InvestInfo.ViewModel
{
    class OperationsVM : ViewModelBase
    {
        private readonly IOperationRepository _operationRepository;
        public ObservableCollection<OperationModel> Operations { get; } = new();
        
        public AsyncRelayCommand AddOperationCommand { get; }
        public AsyncRelayCommand DeleteOperationCommand { get; }

        private string _title = string.Empty;
        public string Title
        {
            get => _title;
            set { _title = value; OnPropertyChanged(); }
        }

        private decimal _amount;
        public decimal Amount
        {
            get => _amount;
            set { _amount = value; OnPropertyChanged(); }
        }

        public OperationsVM(IOperationRepository repository)
        {
            _operationRepository = repository;

            AddOperationCommand = new AsyncRelayCommand(AddAsync);
            DeleteOperationCommand = new AsyncRelayCommand(DeleteAsync);

            _ = LoadAsync();
        }

        private async Task LoadAsync()
        {
            var items = await _operationRepository.GetAllAsync();
            Operations.Clear();
            foreach (var item in items)
                Operations.Add(item);
        }

        private async Task AddAsync(object? obj)
        {
            var operation = new OperationModel
            {
                Title = Title,
                Amount = Amount,
                Date = DateTime.Now
            };

            await _operationRepository.AddAsync(operation);
            await _operationRepository.SaveChangesAsync();

            Operations.Insert(0, operation);

            Title = string.Empty;
            Amount = 0;
        }

        private async Task DeleteAsync(object? obj)
        {
            if (obj is OperationModel operation)
            {
                await _operationRepository.DeleteAsync(operation.Id);
                await _operationRepository.SaveChangesAsync();

                Operations.Remove(operation);
            }
        }
    }
}
