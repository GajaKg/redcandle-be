using System.ComponentModel.DataAnnotations;

namespace API.Dtos.Customer
{
    public class CustomerPostDto
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        public string Contact { get; set; } = string.Empty;

        public string? Note { get; set; } = string.Empty;
    }
}