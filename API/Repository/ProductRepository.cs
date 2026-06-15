using API.Data;
using API.Dtos.Product;
using API.Interfaces;
using API.Mappers;
using API.Models;
using Microsoft.AspNetCore.Mvc;
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
                .AsNoTracking()
                .Include(x => x.Category)
                .Select(p => p.ToProductDto())
                .ToListAsync();
        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            // var product = await _context.Products.FindAsync(id);
            var product = await _context.Products
                            .AsNoTracking()
                            .Include(p => p.Category)
                            .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return null;
            }

            return product.ToProductDto();
        }

        public async Task<Product?> UpdateAsync([FromRoute] int id, [FromBody] ProductUpdateDto productUpdateDto)
        {
            var productModel = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (productModel == null) return null;

            productModel.Name = productUpdateDto.Name;
            productModel.Quantity = productUpdateDto.Quantity;
            productModel.StockCapacity = productUpdateDto.StockCapacity;
            productModel.Reserved = productUpdateDto.Reserved;
            productModel.CategoryId = productUpdateDto.CategoryId;

            await _context.SaveChangesAsync();

            return productModel;
        }
    }
}