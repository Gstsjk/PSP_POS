using Microsoft.AspNetCore.Mvc;
using PSP_PoS.Components.TaxComponent;
using System.ComponentModel;
using System.Data.SqlTypes;

namespace PSP_PoS.Components.TaxComponent
{
    [Route("api/taxes")]
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
        public IActionResult UpdateTax([FromRoute] string id, [FromBody] TaxDto updatedTaxDto)
        {
            if (!System.Guid.TryParse(id, out var taxId))
            {
                return BadRequest("Invalid tax ID format");
            }

            var existingTax = _taxService.GetTaxById(taxId);

            if (existingTax == null)
            {
                return NotFound();
            }
            existingTax.Name = updatedTaxDto.Name;
            existingTax.Rate = updatedTaxDto.Rate;

            _taxService.UpdateTax(updatedTaxDto, Guid.Parse(id));

            return NoContent();
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
