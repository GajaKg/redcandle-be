using API.Dtos.Product;
using API.Interfaces;
using API.Mappers;
using API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _contextProduct;

        public ProductController(IProductRepository contextProduct)
        {
            _contextProduct = contextProduct;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _contextProduct.GetAllAsync();
            // var productsDto = products.Select(p => p.ToProductDto());

            return Ok(products);
            // return Ok(productsDto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var product = await _contextProduct.GetByIdAsync(id);

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
            await _contextProduct.CreateAsync(product);

            return CreatedAtAction(nameof(GetById), new { Id = product.Id }, product.ToProductDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, ProductUpdateDto productUpdateDto)
        {
            var product = await _contextProduct.UpdateAsync(id, productUpdateDto);

            if (product == null) return NotFound();

            return Ok(product.ToProductDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var product = await _contextProduct.DeleteAsync(id);

            if (product == null) return NotFound();

            return NoContent();
        }
    }
}