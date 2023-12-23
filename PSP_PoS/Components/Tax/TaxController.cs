using Microsoft.AspNetCore.Mvc;
using PSP_PoS.Components.Tax;

namespace PSP_PoS.Controllers
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
        public IActionResult AddTax([FromBody] TaxModel tax)
        {
            Console.WriteLine(tax.Id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            _taxService.AddTax(tax);

            return CreatedAtAction(nameof(GetTaxById), new { id = tax.Id }, tax);
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
        public IActionResult UpdateTax([FromRoute] string id, [FromBody] TaxModel updatedTax)
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

            existingTax.Name = updatedTax.Name;
            existingTax.Rate = updatedTax.Rate;

            _taxService.UpdateTax(existingTax);

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
