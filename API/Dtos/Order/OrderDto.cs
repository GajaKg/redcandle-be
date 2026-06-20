using API.Dtos.OrderProductDto;
using API.Models;

namespace API.Dtos.Order
{
    public sealed record OrderDto
    {
        public int Id { get; init; }
        public bool Paid { get; init; }
        public bool Delivered { get; init; }
        public DateTime Date { get; init; }
        public string? Note { get; init; }
        public List<OrderProductDto> OrderProducts { get; init; } = [];
    }

    public sealed record OrderPostDto
    {
        public int CustomerId { get; set; }
        public bool Delivered { get; set; }
        public bool Paid { get; init; }
        public DateTime Date { get; init; }
        public DateTime? DateDelivery { get; set; } = default;
        public string? Note { get; init; }
        // public List<OrderProduct> OrderProducts { get; init; } = [];
        public List<ProductOrderPostDto> OrderProducts { get; init; } = [];

    }

    public class OrderProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; 
        public int Quantity { get; set; }
    }

}