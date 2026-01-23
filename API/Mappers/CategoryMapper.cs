using API.Dtos.Category;
using API.Models;

namespace API.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryDto ToCategoryDto(this Category category)
        {
            return new CategoryDto(category.Name);
        }
    }
}