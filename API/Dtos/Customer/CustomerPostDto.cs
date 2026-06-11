namespace API.Dtos.Customer
{
    public class CustomerPostDto
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Contact { get; set; } = string.Empty;
        public string? Note { get; set; } = string.Empty;
    }
}