using Microsoft.AspNetCore.Mvc;

namespace PSP_PoS.Components.DiscountComponent
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpPost]
        public IActionResult AddDiscount([FromBody] DiscountDto discountDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Discount discount = _discountService.AddDiscount(discountDto);

            return CreatedAtAction(nameof(AddDiscount), discount);
        }


        [HttpGet("{id}")]
        public IActionResult GetDiscountById([FromRoute] string id)
        {
            if (!System.Guid.TryParse(id, out var taxId))
            {
                return BadRequest("Invalid tax ID format");
            }

            var discount = _discountService.GetDiscountById(taxId);

            if (discount == null)
            {
                return NotFound();
            }

            return Ok(discount);
        }

        [HttpGet]
        public IActionResult GetDiscounts()
        {
            var discounts = _discountService.GetDiscounts();
            return Ok(discounts);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDiscount([FromRoute] string id, [FromBody] DiscountDto discountDto)
        {
            if (!System.Guid.TryParse(id, out var discountId))
            {
                return BadRequest("Invalid tax ID format");
            }

            if(_discountService.UpdateDiscount(discountDto, discountId))
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
        public IActionResult DeleteDiscount([FromRoute] string id)
        {
            if (!System.Guid.TryParse(id, out var discountId))
            {
                return BadRequest("Invalid tax ID format");
            }


            if (_discountService.DeleteDiscount(discountId))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Record not found.");
            }
        }
    }
}
