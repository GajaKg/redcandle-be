using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public int? CustomerOrderId { get; set; }
        [Required]
        public required string Name { get; set; }
        public string Address { get; set; } = String.Empty;
        public string Contact { get; set; } = String.Empty;
        public string Note { get; set; } = String.Empty;

        public List<CustomerOrder> Orders { get; set; } = new List<CustomerOrder>();
    }
}