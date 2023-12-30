using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;

namespace PSP_PoS.Components.DiscountComponent
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public IActionResult GetAllDiscounts()
        {
            var discountReadDto = _discountService.GetAllDiscounts();
            return Ok(discountReadDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetDiscountById([FromRoute] string id)
        {
            if (!System.Guid.TryParse(id, out var discountId))
            {
                return BadRequest("Invalid discount ID format");
            }

            var discount = _discountService.GetDiscountById(discountId);
            if(discount == null)
            {
                return NotFound();
            }
            return Ok(discount);
        }

        [HttpPost]
        public IActionResult AddDiscount([FromBody] DiscountCreateDto discountCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var discount = _discountService.AddDiscount(discountCreateDto);
            return CreatedAtAction(nameof(AddDiscount), discount);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDiscount([FromRoute] string id, [FromBody] DiscountCreateDto discountCreateDto)
        {
            if(!System.Guid.TryParse (id, out var discountId))
            {
                return BadRequest("Invalid discount ID format");
            }

            if(_discountService.UpdateDiscount(discountCreateDto, discountId))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Record not found");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount([FromRoute] string id)
        {
            if(!System.Guid.TryParse(id, out var discountId))
            {
                return BadRequest("Invalid discount ID format");
            }
            var discount = _discountService.GetDiscountById(discountId);
            if(discount == null)
            {
                return NotFound();
            }
            _discountService.DeleteDiscount(discountId);
            return NoContent();
        }
    }
}
