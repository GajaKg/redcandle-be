using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public int StockCapacity { get; set; }
        public int Reserved { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public List<Production> Productions { get; set; } = [];
        public List<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }

}