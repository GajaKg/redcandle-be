using API.Dtos.Product;
using API.Models;

namespace API.Interfaces
{
    public interface IProductRepository
    {
        Task<List<ProductDto>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task<Product> CreateAsync(Product product);
        Task<Product?> UpdateAsync(int id, ProductUpdateDto productUpdateDto);
        Task<Product?> DeleteAsync(int id);
    }
}