using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Contact { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;

        public List<CustomerOrder> CustomerOrders { get; set; } = new List<CustomerOrder>();
    }
}