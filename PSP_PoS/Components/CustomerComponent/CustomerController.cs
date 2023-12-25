using Microsoft.AspNetCore.Mvc;

namespace PSP_PoS.Components.CustomerComponent
{

    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public IActionResult AddCustomer([FromBody] CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Customer customer = _customerService.AddCustomer(customerDto);

            return CreatedAtAction(nameof(AddCustomer), customer);
        }


        [HttpGet("{id}")]
        public IActionResult GetCustomerById([FromRoute] string id)
        {
            if (!System.Guid.TryParse(id, out var customerId))
            {
                return BadRequest("Invalid customer ID format");
            }

            var customer = _customerService.GetCustomerById(customerId);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpGet("email/{email}")]
        public IActionResult GetCustomerByEmail([FromRoute] string email)
        {
            var customer = _customerService.GetCustomerByEmail(email);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            var customers = _customerService.GetCustomers();
            return Ok(customers);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer([FromRoute] string id,[FromBody] CustomerDto customerDto)
        {
            if (!System.Guid.TryParse(id, out var customerId))
            {
                return BadRequest("Invalid customer ID format");
            }

            if (_customerService.UpdateCustomer(customerDto, customerId))
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
            if (!System.Guid.TryParse(id, out var customerId))
            {
                return BadRequest("Invalid customer ID format");
            }


            if (_customerService.DeleteCustomer(customerId))
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
