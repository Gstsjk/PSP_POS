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

        [HttpGet]
        public ActionResult GetAllEmployees()
        {
            var employeeReadDto = _employeeService.GetAllEmployees();
            return Ok(employeeReadDto);
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

        [HttpPost]
        public ActionResult AddEmployee([FromBody] EmployeeCreateDto employeeCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var employee = _employeeService.AddEmployee(employeeCreateDto);
            return CreatedAtAction(nameof(AddEmployee), employee);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee([FromRoute] string id, [FromBody] EmployeeCreateDto employeeCreateDto)
        {
            if (!System.Guid.TryParse(id, out var employeeId))
            {
                return BadRequest("Invalid employee ID format");
            }
            if(_employeeService.UpdateEmployee(employeeCreateDto, employeeId))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Record not found");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee([FromRoute] string id)
        {
            if (!System.Guid.TryParse(id, out var employeeId))
            {
                return BadRequest("Invalid employee ID format");
            }
            var employee = _employeeService.GetEmployeeById(employeeId);
            if(employee == null)
            {
                return NotFound();
            }
            _employeeService.DeleteEmployee(employeeId);
            return NoContent();
        }
    }
}