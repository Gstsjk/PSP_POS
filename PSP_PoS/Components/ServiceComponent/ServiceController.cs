using Microsoft.AspNetCore.Mvc;
using PSP_PoS.Components.ItemComponent;
using System.Runtime.CompilerServices;

namespace PSP_PoS.Components.ServiceComponent
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public IActionResult GetAllServices()
        {
            var servicesReadDto = _serviceService.GetAllServices();
            return Ok(servicesReadDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetServiceById([FromRoute] string id)
        {
            if (!System.Guid.TryParse(id, out var serviceId))
            {
                return BadRequest("Invalid service ID format");
            }
            var service = _serviceService.GetServiceById(serviceId);
            if(service == null)
            {
                return NotFound();
            }
            return Ok(service);
        }

        [HttpPost]
        public IActionResult AddService([FromBody] ServiceCreateDto serviceCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(!_serviceService.IfCategoryIdValid(serviceCreateDto.CategoryId))
            {
                return BadRequest("Category ID not found");
            }
            var service = _serviceService.AddService(serviceCreateDto);
            return CreatedAtAction(nameof(AddService), service);
        }

        [HttpPut("{serviceId} {discountId} | Add Discount to service")]
        public IActionResult AddDiscountItem([FromRoute] string serviceId, [FromRoute] string discountId)
        {
            if (!System.Guid.TryParse(serviceId, out Guid serviceIdGuid))
            {
                return BadRequest("Invalid service ID format");
            }
            if (!System.Guid.TryParse(discountId, out Guid discountIdGuid))
            {
                return BadRequest("Invalid discount ID format");
            }
            if (!_serviceService.IfServiceIdValid(serviceIdGuid))
            {
                return BadRequest("Service ID not found");
            }
            if (!_serviceService.IfDiscountIdValid(discountIdGuid))
            {
                return BadRequest("Category ID not found");
            }
            if (_serviceService.AddDiscountToService(serviceIdGuid, discountIdGuid))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Record not found");
            }
        }

        [HttpPut("{serviceId} | Remove Discount from Service")]
        public IActionResult RemoveDiscountItem([FromRoute] string serviceId)
        {
            if (!System.Guid.TryParse(serviceId, out Guid serviceIdGuid))
            {
                return BadRequest("Invalid service ID format");
            }
            if (!_serviceService.IfServiceIdValid(serviceIdGuid))
            {
                return BadRequest("Service ID not found");
            }

            if (_serviceService.RemoveDiscountFromService(serviceIdGuid))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Record not found");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateService([FromRoute] string id, [FromBody] ServiceCreateDto serviceCreateDto)
        {
            if (!System.Guid.TryParse(id, out var serviceId))
            {
                return BadRequest("Invalid item ID format");
            }

            if (_serviceService.UpdateService(serviceCreateDto, serviceId))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Record not found");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteService([FromRoute] string id)
        {
            if (!System.Guid.TryParse(id, out var serviceId))
            {
                return BadRequest("Invalid service ID format");
            }
            var item = _serviceService.GetServiceById(serviceId);
            if (item == null)
            {
                return NotFound();
            }
            _serviceService.DeleteService(serviceId);
            return NoContent();
        }
    }
}
