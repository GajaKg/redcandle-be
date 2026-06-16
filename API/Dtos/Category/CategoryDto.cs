
using API.Dtos.Product;

namespace API.Dtos.Category
{
   public sealed record CategoryDto (
        int Id,
        string Name,
        List<ProductDto> Products
   );
}