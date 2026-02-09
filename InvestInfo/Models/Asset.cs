using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InvestInfo.Models
{
    internal class Asset
    {
        public int Id { get; set; }
        [Required] public string Ticker { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Type { get; set; } // "Stock", "Bond", "ETF"
        [Required] public string Currency { get; set; } = "RUB";
        public string? Sector { get; set; }

        // Связь: один актив - много операций
        public List<Operation> Operations { get; set; } = new List<Operation>();
    }
}
