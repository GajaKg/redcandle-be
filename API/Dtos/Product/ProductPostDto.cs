using System.ComponentModel.DataAnnotations;

namespace API.Dtos.Product
{
    public class ProductPostDto
    {
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; } = 0;
        public int StockCapacity { get; set; } = 0;
        public int Reserved { get; set; } = 0;
        [Required]
        public int CategoryId { get; set; }
    }
}