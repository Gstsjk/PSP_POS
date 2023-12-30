using Microsoft.AspNetCore.Mvc;


namespace PSP_PoS.Components.CategoryComponent
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categoriesReadDto = _categoryService.GetAllCategories();
            return Ok(categoriesReadDto);
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

        [HttpPost]
        public IActionResult AddCategory([FromBody] CategoryCreateDto categoryCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var category = _categoryService.AddCategory(categoryCreateDto);
            return CreatedAtAction(nameof(AddCategory), category);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory([FromRoute] string id, [FromBody] CategoryCreateDto categoryCreateDto)
        {
            if (!System.Guid.TryParse(id, out var categoryId))
            {
                return BadRequest("Invalid category ID format");
            }

            if (_categoryService.UpdateCategory(categoryCreateDto, categoryId))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Record not found");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory([FromRoute] string id)
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
            _categoryService.DeleteCategory(categoryId);
            return NoContent();
        }
    }
}

