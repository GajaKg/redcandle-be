namespace API.Dtos.Customer
{
    public class CustomerUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Contact { get; set; } = string.Empty;
        public string? Note { get; set; } = string.Empty;
    }
}