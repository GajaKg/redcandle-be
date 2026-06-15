namespace API.Dtos.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public int StockCapacity { get; set; }
        public int Reserved { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }
}