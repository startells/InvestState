using System;
using System.Collections.Generic;
using System.Text;

namespace InvestInfo.Models
{
    internal class Portfolio
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Связь: один портфель - много операций
        public List<Operation> Operations { get; set; } = new List<Operation>();
    }
}
