using API.Dtos.Category;
using API.Interfaces;
using API.Mappers;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository contextCategory)
        {
            _categoryRepository = contextCategory;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            // var mapped = categories.Select(c => c.ToCategoryDto());
            // add dto mapper
            return Ok(categories);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null) return NotFound();

            return Ok(category.ToCategoryDto());
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> CreateAsync(CategoryPostDto categoryPostDto)
        {
            var categoryModel = new Category
            {
                Name = categoryPostDto.Name
            };

            var result = await _categoryRepository.CreateAsync(categoryModel);
            if (result == null) return BadRequest();

            return Ok(result.ToCategoryDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<CategoryDto>> EditAsync([FromRoute] int id, [FromBody] CategoryPostDto categoryPostDto)
        {
            var categoryModel = new Category
            {
                Id = id,
                Name = categoryPostDto.Name
            };

            var response = await _categoryRepository.UpdateAsync(id, categoryModel);

            if (response == null) return BadRequest();

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var deletedCategory = await _categoryRepository.DeleteAsync(id);

            if (deletedCategory == null) return NotFound();

            return NoContent();
        }
    }
};