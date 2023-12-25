using Microsoft.AspNetCore.Mvc;
using PSP_PoS.Components.CategoryComponent;
using PSP_PoS.Components.DiscountComponent;


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
        public IActionResult UpdateCategory([FromRoute] string id, [FromBody] CategoryDto categoryDto)
        {
            if (!System.Guid.TryParse(id, out var categoryId))
            {
                return BadRequest("Invalid category ID format");
            }

            if (_categoryService.UpdateCategory(categoryDto, categoryId))
            {
                return StatusCode(201);
                //return Ok();
            }
            else
            {
                return BadRequest("Record not found.");
            }
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

