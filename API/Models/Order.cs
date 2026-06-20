namespace API.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public bool Paid { get; set; }
        public bool Delivered { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public DateTime? DateDelivery { get; set; } = default;
        public string? Note { get; set; } = default;

        public Customer Customer { get; set; } = null!;
        public List<OrderProduct> OrderProducts { get; set; } = [];
    }
}