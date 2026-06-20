namespace API.Dtos.OrderProductDto
{
    public sealed record ProductOrderPostDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}