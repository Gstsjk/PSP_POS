using Microsoft.AspNetCore.Mvc;
using PSP_PoS.Components.DiscountComponent;
using PSP_PoS.Components.TaxComponent;
using System.ComponentModel;
using System.Data.SqlTypes;

namespace PSP_PoS.Components.TaxComponent
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxController : ControllerBase
    {
        private readonly ITaxService _taxService;

        public TaxController(ITaxService taxService)
        {
            _taxService = taxService;
        }

        [HttpPost]
        public IActionResult AddTax([FromBody] TaxDto taxDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var tax =_taxService.AddTax(taxDto);

            return CreatedAtAction(nameof(AddTax), tax);
        }

        [HttpGet("{id}")]
        public IActionResult GetTaxById([FromRoute] string id)
        {
            if (!System.Guid.TryParse(id, out var taxId))
            {
                return BadRequest("Invalid tax ID format");
            }

            var tax = _taxService.GetTaxById(taxId);

            if (tax == null)
            {
                return NotFound();
            }

            return Ok(tax);
        }

        [HttpGet]
        public IActionResult GetTaxes()
        {
            var taxes = _taxService.GetAllTaxes();
            return Ok(taxes);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTax([FromRoute] string id, [FromBody] TaxDto taxDto)
        {
            if (!System.Guid.TryParse(id, out var taxId))
            {
                return BadRequest("Invalid tax ID format");
            }

            if (_taxService.UpdateTax(taxDto, taxId))
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
        public IActionResult DeleteTax([FromRoute] string id)
        {
            if (!System.Guid.TryParse(id, out var taxId))
            {
                return BadRequest("Invalid tax ID format");
            }

            var tax = _taxService.GetTaxById(taxId);

            if (tax == null)
            {
                return NotFound();
            }

            _taxService.DeleteTax(taxId);

            return NoContent();
        }
    }
}
