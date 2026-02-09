using System.ComponentModel.DataAnnotations;

namespace InvestInfo.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)] 
        public string Name { get; set; } = string.Empty;

        [MaxLength(20)] 
        public string? Color { get; set; } // Для UI

        // Связь: одна категория - много операций
        public List<Operation>? Operations { get; set; }
    }
}
