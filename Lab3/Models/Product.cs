using System.ComponentModel.DataAnnotations.Schema;

namespace Lab3.Models
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required decimal Price { get; set; } // Цена за единицу
    }

}
