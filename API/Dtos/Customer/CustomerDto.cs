using API.Dtos.Order;

namespace API.Dtos.Customer
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Contact { get; set; } = string.Empty;
        public string? Note { get; set; } = string.Empty;
        public DateTime Date { get; set; }

        // public List<OrderDto> Orders { get; set; } = [];
    }
    public class CustomerWithOrdersDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Contact { get; set; } = string.Empty;
        public string? Note { get; set; } = string.Empty;
        public DateTime Date { get; set; }

        public List<OrderDto> Orders { get; set; } = [];
    }
}