using Microsoft.AspNetCore.Mvc;
using PSP_PoS.Components.CustomerComponent;

namespace PSP_PoS.Components.EmployeeComponent
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody] EmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Employee employee = _employeeService.AddEmployee(employeeDto);

            return CreatedAtAction(nameof(AddEmployee), employee);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById([FromRoute] string id)
        {
            if (!System.Guid.TryParse(id, out var employeeId))
            {
                return BadRequest("Invalid employee ID format");
            }

            var employee = _employeeService.GetEmployeeById(employeeId);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = _employeeService.GetEmployees();
            return Ok(employees);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee([FromRoute] string id, [FromBody] EmployeeDto employeeDto)
        {
            if (!System.Guid.TryParse(id, out var employeeId))
            {
                return BadRequest("Invalid employee ID format");
            }

            if (_employeeService.UpdateEmployee(employeeDto, employeeId))
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
        public IActionResult DeleteEmployee([FromRoute] string id)
        {
            if (!System.Guid.TryParse(id, out var employeeId))
            {
                return BadRequest("Invalid customer ID format");
            }


            if (_employeeService.DeleteEmployee(employeeId))
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
