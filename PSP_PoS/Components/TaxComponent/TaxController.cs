using Microsoft.AspNetCore.Mvc;
using PSP_PoS.Components.CategoryComponent;

namespace PSP_PoS.Components.TaxComponent
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxController : Controller
    {
        private readonly ITaxService _taxService;

        public TaxController(ITaxService taxService)
        {
            _taxService = taxService;
        }

        [HttpGet]
        public IActionResult GetAllTaxes()
        {
            var taxesReadDto = _taxService.GetAllTaxes();
            return Ok(taxesReadDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetTaxById([FromRoute] string id)
        {
            if (!System.Guid.TryParse(id, out var taxId))
            {
                return BadRequest("Invalid tax ID format");
            }
            var tax = _taxService.GetTaxById(taxId);
            if(tax == null)
            {
                return NotFound();
            }
            return Ok(tax);
        }

        [HttpPost]
        public IActionResult AddTax([FromBody] TaxCreateDto taxCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var tax = _taxService.AddTax(taxCreateDto);
            return CreatedAtAction(nameof(AddTax), tax);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTax([FromRoute] string id, [FromBody] TaxCreateDto taxCreateDto)
        {
            if (!System.Guid.TryParse(id, out var taxId))
            {
                return BadRequest("Invalid tax ID format");
            }

            if(_taxService.UpdateTax(taxCreateDto, taxId))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Record not found");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTax([FromRoute] string id)
        {
            if (!System.Guid.TryParse(id, out var taxId))
            {
                return BadRequest("Invalid tax ID format");
            }
            var tax = _taxService.GetTaxById(taxId);
            if(tax == null)
            {
                return NotFound();
            }
            _taxService.DeleteTax(taxId);
            return NoContent();
        }
    }
}
