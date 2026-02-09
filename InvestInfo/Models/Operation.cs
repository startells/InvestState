using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvestInfo.Models
{
    public enum OperationType
    {
        Buy,
        Sell
    }

    internal class Operation
    {
        [Key] public int Id { get; set; }

        [Required] public DateTime Date { get; set; }
        [Required] public OperationType Type { get; set; }
        [Required][MaxLength(20)] public string Ticker { get; set; }

        /* Добавил от себя Required ниже */ 
        [Required] public int Quantity { get; set; }

        [Required][Column(TypeName = "decimal(18,4)")] public decimal Price { get; set; }
        [Column(TypeName = "decimal(18,4)")] public decimal Commission { get; set; }

        [MaxLength(500)] public string? Notes { get; set; }

        // Навигационные свойства (связи)
        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        public int? PortfolioId { get; set; }
        public Portfolio Portfolio { get; set; }

        // Вычисляемое свойство (не сохраняется в БД)
        [NotMapped] public decimal Total => Price * Quantity;
    }
}
