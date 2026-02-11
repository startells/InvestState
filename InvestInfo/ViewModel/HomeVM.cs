using System;
using System.Collections.Generic;
using System.Text;
using InvestInfo.Model;

namespace InvestInfo.ViewModel
{
    public class HomeVM : Utilities.ViewModelBase
    {
        private readonly PortfolioModel _portfolioModel;
        public decimal Cost
        {
            get { return _portfolioModel.Cost; }
            set { _portfolioModel.Cost = value; OnPropertyChanged(); }
        }

        public DateOnly CreateDate
        {
            get { return _portfolioModel.CreateDate; }
            set { _portfolioModel.CreateDate = value; OnPropertyChanged(); }
        }

        public HomeVM()
        {
            _portfolioModel = new PortfolioModel();

            Cost = 1000m; // Example initial value
            CreateDate = DateOnly.FromDateTime(DateTime.Now); // Example initial value
        }
    }
}
