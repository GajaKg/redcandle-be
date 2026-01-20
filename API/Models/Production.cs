namespace API.Models
{
    public class Production
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public DateOnly ProductionDate { get; set; }
        public int Quantity { get; set; }

        public Product Product { get; set; } = null!;
    }
}