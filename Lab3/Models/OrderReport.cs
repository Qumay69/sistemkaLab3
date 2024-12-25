namespace Lab3.Models
{
    public class OrderReport
    {
        public string ProductName { get; set; }  // Название продукта
        public int TotalQuantity { get; set; }   // Общее количество
        public decimal TotalRevenue { get; set; } // Общая сумма выручки
    }
}
