using API.Dtos.Product;
using API.Interfaces;
using API.Mappers;
using API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository contextProduct)
        {
            _productRepository = contextProduct;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productRepository.GetAllAsync();
            // var productsDto = products.Select(p => p.ToProductDto());

            return Ok(products);
            // return Ok(productsDto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductPostDto productPostDto)
        {
            var product = productPostDto.FromProductPostDtoToProduct();
            await _productRepository.CreateAsync(product);

            var dto = await _productRepository.GetByIdAsync(product.Id);

            return CreatedAtAction(
                nameof(GetById),
                new { id = dto!.Id },
                dto
            );
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<ProductDto>> Update([FromRoute] int id, ProductUpdateDto productUpdateDto)
        {
            var product = await _productRepository.UpdateAsync(id, productUpdateDto);

            if (product == null) return NotFound();
            
            var productDto = await _productRepository.GetByIdAsync(product.Id);

            return Ok(productDto);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var product = await _productRepository.DeleteAsync(id);

            if (product == null) return NotFound();

            return NoContent();
        }
    }
}