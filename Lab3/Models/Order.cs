using System.Text.Json.Serialization;

namespace Lab3.Models
{
    public class Order
    {
        public int Id { get; set; }
        public required string Customer { get; set; }
        public int ProductId { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public required  DateTime OrderDate { get; set; }
        public required decimal TotalAmount { get; set; }
        public required bool IsCompleted { get; set; }
    }
}

