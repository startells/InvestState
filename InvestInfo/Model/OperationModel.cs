using System;
using System.Collections.Generic;
using System.Text;

namespace InvestInfo.Model
{
    public class OperationModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
