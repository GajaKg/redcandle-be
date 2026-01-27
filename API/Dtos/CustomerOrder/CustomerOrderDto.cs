namespace API.Dtos.Order
{
public sealed record CustomerOrderDto
{
    public int Id { get; init; }
    public DateTime Date { get; init; }
    public bool Paid { get; init; }
    public bool Delivered { get; init; }
    public string? Note { get; init; }
    public List<OrderProductDto> Products { get; init; } = [];
}



    public class OrderProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }

}