using API.Models;

namespace API.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
        Task<Customer> CategoryCreateAsync(Category category);
        Task<Category?> UpdateAsync(int id, Category categoryUpdateDto);
        Task<Category> DeleteAsync(int id);
    }
}