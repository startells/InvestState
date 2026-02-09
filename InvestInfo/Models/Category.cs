namespace InvestInfo.Models
{
    internal class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; } // Для UI

        // Связь: одна категория - много операций
        public List<Operation> Operations { get; set; } = new List<Operation>();
    }
}
