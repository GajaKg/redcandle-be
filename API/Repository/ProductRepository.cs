using API.Data;
using API.Dtos.Product;
using API.Interfaces;
using API.Mappers;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext _context;

        public ProductRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> DeleteAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return null;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            return await _context.Products
                .Include(x => x.Category)
                .Select(p => p.ToProductDto())
                .ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return null;
            }

            return product;
        }

        public async Task<Product?> UpdateAsync(int id, ProductUpdateDto productUpdateDto)
        {
            var productModel = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (productModel == null) return null;

            var product = new Product
            {
                Name = productUpdateDto.Name,
                Quantity = productUpdateDto.Quantity,
                StockCapacity = productUpdateDto.StockCapacity,
                Reserved = productUpdateDto.Reserved,
            };

            await _context.SaveChangesAsync();

            return product;
        }
    }
}