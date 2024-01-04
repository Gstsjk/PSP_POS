using Microsoft.AspNetCore.Mvc;
using PSP_PoS.Components.ItemComponent;

namespace PSP_PoS.Components.OrderComponent
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost(" | Create Initial Order")]
        public IActionResult CreateOrder([FromBody] OrderCreateDto orderCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_orderService.IfEmployeeIdValid(orderCreateDto.EmployeeId))
            {
                return BadRequest("Employee ID not found");
            }
            if (!_orderService.IfCustomerIdValid(orderCreateDto.CustomerId))
            {
                return BadRequest("Customer ID not found");
            }
            var order = _orderService.AddOrder(orderCreateDto);
            return CreatedAtAction(nameof(CreateOrder), order);
        }

        [HttpPost("{orderId} {itemId} | Add Item To Order")]
        public IActionResult AddItem([FromRoute] string orderId, [FromRoute] string itemId)
        {
            if (!System.Guid.TryParse(orderId, out var orderIdGuid))
            {
                return BadRequest("Invalid order ID format.");
            }
            if (!System.Guid.TryParse(itemId, out var itemIdGuid))
            {
                return BadRequest("Invalid item ID format.");
            }
            if (!_orderService.IfOrderIdValid(orderIdGuid))
            {
                return NotFound("Order not found.");
            }
            if (!_orderService.IfItemIdValid(itemIdGuid))
            {
                return NotFound("Item not found.");
            }
            if(!_orderService.IfItemExists(itemIdGuid))
            {
                return BadRequest("No more stock left.");
            }

            var orderItem = _orderService.AddItemToOrder(orderIdGuid, itemIdGuid);
            return CreatedAtAction(nameof(AddItem), orderItem);
        }

        [HttpPost("{orderId} {serviceId} | Add Service to Order")]
        public IActionResult AddService([FromRoute] string orderId, [FromRoute] string serviceId)
        {
            if (!System.Guid.TryParse(orderId, out var orderIdGuid))
            {
                return BadRequest("Invalid order ID format.");
            }
            if (!System.Guid.TryParse(serviceId, out var serviceIdGuid))
            {
                return BadRequest("Invalid service ID format.");
            }
            if (!_orderService.IfOrderIdValid(orderIdGuid))
            {
                return NotFound("Order not found.");
            }
            if (!_orderService.IfServiceIdValid(serviceIdGuid))
            {
                return NotFound("Service not found.");
            }

            var orderService = _orderService.AddServiceToOrder(orderIdGuid, serviceIdGuid);
            return CreatedAtAction(nameof(AddService), orderService);
        }

        [HttpGet("{id}")]
        public ActionResult GetOrderById([FromRoute] string id)
        {
            if (!System.Guid.TryParse(id, out var itemId))
            {
                return BadRequest("Invalid order ID format");
            }
            var order = _orderService.GetOrderById(itemId);
            if(order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpGet]
        public ActionResult GetAllOrders()
        {
            var ordersReadDto = _orderService.GetAllOrders();
            return Ok(ordersReadDto);
        }

        [HttpPut("{orderId} {itemId} | Remove Item From Order")]
        public ActionResult RemoveItemFromOrder([FromRoute] string orderId, [FromRoute] string itemId)
        {
            if (!System.Guid.TryParse(orderId, out Guid orderIdGuid))
            {
                return BadRequest("Invalid order ID format");
            }
            if (!System.Guid.TryParse(itemId, out Guid itemIdGuid))
            {
                return BadRequest("Invalid item ID format");
            }
            if(_orderService.RemoveItemFromOrder(orderIdGuid, itemIdGuid))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Item not found in order");
            }
        }

    }
}
