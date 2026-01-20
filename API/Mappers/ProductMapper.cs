using API.Dtos.Product;
using API.Models;

namespace API.Mappers
{
    public static class ProductMapper
    {
        public static ProductDto ToProductDto(this Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Quantity = product.Quantity,
                StockCapacity = product.StockCapacity,
                Reserved = product.Reserved
            };
        }

        public static Product FromProductPostDtoToProduct(this ProductPostDto productPostDto)
        {
            return new Product
            {
                Name = productPostDto.Name,
                Quantity = productPostDto.Quantity,
                StockCapacity = productPostDto.StockCapacity,
                Reserved = productPostDto.Reserved
            };
        }
    }
}