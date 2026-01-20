using API.Data;
using API.Dtos.Product;
using API.Mappers;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;

        public ProductController(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _dbContext.Products.ToListAsync();
            var productsDto = products.Select(p => p.ToProductDto());

            return Ok(productsDto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var product = await _dbContext.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product.ToProductDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductPostDto productPostDto)
        {
            var product = productPostDto.FromProductPostDtoToProduct();
            await _dbContext.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { Id = product.Id }, product.ToProductDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, ProductUpdateDto productUpdateDto)
        {
            var productModel = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (productModel == null) return NotFound();

            var product = new Product
            {
                Name = productUpdateDto.Name,
                Quantity = productUpdateDto.Quantity,
                StockCapacity = productUpdateDto.StockCapacity,
                Reserved = productUpdateDto.Reserved,
            };

            await _dbContext.SaveChangesAsync();

            return Ok(product.ToProductDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return NotFound();

            _dbContext.Remove(product);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}