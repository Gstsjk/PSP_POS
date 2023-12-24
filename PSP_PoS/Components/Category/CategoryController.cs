using Microsoft.AspNetCore.Mvc;
using PSP_PoS.Components.Category;


namespace PSP_PoS.Components.Category
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : Controller
    {
      
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public IActionResult AddCategory([FromBody] CategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = _categoryService.AddCategory(categoryDto);

            return CreatedAtAction(nameof(AddCategory), category);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById([FromRoute] string id)
        {
            if (!System.Guid.TryParse(id, out var categoryId))
            {
                return BadRequest("Invalid category ID format");
            }

            var category = _categoryService.GetCategoryById(categoryId);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _categoryService.GetAllCategories();
            return Ok(categories);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory([FromRoute] string id, [FromBody] CategoryDto updatedCategoryDto)
        {
            if (!System.Guid.TryParse(id, out var categoryId))
            {
                return BadRequest("Invalid category ID format");
            }

            var existingCategory = _categoryService.GetCategoryById(categoryId);

            if (existingCategory == null)
            {
                return NotFound();
            }

            existingCategory.Name = updatedCategoryDto.Name;
              
            _categoryService.UpdateCategory(updatedCategoryDto, Guid.Parse(id));

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory([FromRoute] string id)
        {
            if (!System.Guid.TryParse(id, out var categoryId))
            {
                return BadRequest("Invalid category ID format");
            }

            var tax = _categoryService.GetCategoryById(categoryId);

            if (tax == null)
            {
                return NotFound();
            }

            _categoryService.DeleteCategory(categoryId);

            return NoContent();
        }
    }
}

