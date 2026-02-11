using InvestInfo.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestInfo.ViewModel
{
    class OperationsVM : Utilities.ViewModelBase
    {
        private readonly OperationModel _operationModel;

        public int OperationId
        {
            get { return _operationModel.OperationId; }
            set { _operationModel.OperationId = value; OnPropertyChanged(); }
        }

        public string OperationName
        {
            get { return _operationModel.OperationName; }
            set { _operationModel.OperationName = value; OnPropertyChanged(); }
        }

        public OperationsVM()
        {
            _operationModel = new OperationModel();
            OperationId = 1; // Example initial value
            OperationName = "Buy"; // Example initial value
        }
    }
}
