using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InvestInfo.Models
{
    public class Asset
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string Ticker { get; set; } = string.Empty;

        [MaxLength(200)]
        public string? Name { get; set; }

        [MaxLength(50)]
        public string? Type { get; set; }

        [MaxLength(3)]
        public string Currency { get; set; } = "RUB";

        [MaxLength(100)]
        public string? Sector { get; set; }

        public List<Operation>? Operations { get; set; }
    }
}
