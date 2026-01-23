using API.Data;
using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDBContext _context;
        
        public CategoryRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Task<Customer> CategoryCreateAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<Category> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null) return null;

            return category; 
        }

        public Task<Category?> UpdateAsync(int id, Category categoryUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}