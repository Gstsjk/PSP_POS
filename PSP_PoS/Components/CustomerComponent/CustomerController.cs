using Microsoft.AspNetCore.Mvc;
using PSP_PoS.Components.CategoryComponent;

namespace PSP_PoS.Components.CustomerComponent
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var customerReadDto = _customerService.GetAllCustomers();
            return Ok(customerReadDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById([FromRoute] string id)
        {
            if (!System.Guid.TryParse(id, out var customerId))
            {
                return BadRequest("Invalid customer ID format");
            }
            var customer = _customerService.GetCustomerById(customerId);
            if(customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public IActionResult AddCustomer([FromBody] CustomerCreateDto customerCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var customer = _customerService.AddCustomer(customerCreateDto);
            return CreatedAtAction(nameof(AddCustomer), customer);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer([FromRoute] string id, [FromBody] CustomerCreateDto customerCreateDto)
        {
            if (!System.Guid.TryParse(id, out var customerId))
            {
                return BadRequest("Invalid customer ID format");
            }
            if(_customerService.UpdateCustomer(customerCreateDto, customerId))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Record not found");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer([FromRoute] string id)
        {
            if (!System.Guid.TryParse(id, out var customerId))
            {
                return BadRequest("Invalid customer ID format");
            }
            var customer = _customerService.GetCustomerById(customerId);
            if(customer == null)
            {
                return NotFound();
            }
            _customerService.DeleteCustomer(customerId);
            return NoContent();
        }
    }
}
