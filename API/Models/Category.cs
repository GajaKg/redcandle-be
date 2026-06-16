using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Category
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; } = String.Empty;

        public List<Product> Products { get; set; } = new List<Product>();
    }
}