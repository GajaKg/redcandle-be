using API.Data;
using API.Dtos.Category;
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

        public async Task<Category> CreateAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<Category?> DeleteAsync(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null) return null;

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories
                .AsNoTracking()
                .OrderBy(c => c.Id)
                .ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            var category = await _context.Categories
                                    .Include(c => c.Products)
                                    .FirstOrDefaultAsync(c => c.Id == id);
            // .FindAsync(id);

            if (category == null) return null;

            return category;
        }

        public async Task<Category?> UpdateAsync(int id, Category category)
        {
            var categoryModel = await _context.Categories.FindAsync(id);

            if (category == null) return null;

            categoryModel!.Name = category.Name;

            await _context.SaveChangesAsync();

            return categoryModel;
        }
    }
}