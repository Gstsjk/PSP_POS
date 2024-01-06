using Microsoft.AspNetCore.Mvc;
using PSP_PoS.Components.ItemComponent;
using PSP_PoS.Components.ServiceComponent;
using PSP_PoS.Enums;

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
            if (!_orderService.IfItemExists(itemIdGuid))
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
        public IActionResult GetOrderById([FromRoute] string id)
        {
            if (!System.Guid.TryParse(id, out var itemId))
            {
                return BadRequest("Invalid order ID format");
            }
            var order = _orderService.GetOrderById(itemId);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var ordersReadDto = _orderService.GetAllOrders();
            return Ok(ordersReadDto);
        }

        [HttpPut("{orderId} {itemId} | Remove Item From Order")]
        public IActionResult RemoveItemFromOrder([FromRoute] string orderId, [FromRoute] string itemId)
        {
            if (!System.Guid.TryParse(orderId, out Guid orderIdGuid))
            {
                return BadRequest("Invalid order ID format");
            }
            if (!System.Guid.TryParse(itemId, out Guid itemIdGuid))
            {
                return BadRequest("Invalid item ID format");
            }
            if (_orderService.RemoveItemFromOrder(orderIdGuid, itemIdGuid))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Item not found in order");
            }
        }

        [HttpPut("{orderId} {serviceId} | Remove Service From Order")]
        public IActionResult RemoveServiceFromOrder([FromRoute] string orderId, [FromRoute] string serviceId)
        {
            if (!System.Guid.TryParse(orderId, out Guid orderIdGuid))
            {
                return BadRequest("Invalid order ID format");
            }
            if (!System.Guid.TryParse(serviceId, out Guid serviceIdGuid))
            {
                return BadRequest("Invalid service ID format");
            }
            if (_orderService.RemoveServiceFromOrder(orderIdGuid, serviceIdGuid))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Service not found in order");
            }

        }

        [HttpPut("{orderId} {taxId} | Add Tax to Order")]
        public IActionResult AddTaxToOrder([FromRoute] string orderId, [FromRoute] string taxId)
        {
            if (!System.Guid.TryParse(orderId, out Guid orderIdGuid))
            {
                return BadRequest("Invalid order ID format");
            }
            if (!System.Guid.TryParse(taxId, out Guid taxIdGuid))
            {
                return BadRequest("Invalid tax ID format");
            }
            if (_orderService.AddTaxToOrder(orderIdGuid, taxIdGuid))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Tax not found");
            }
        }

        [HttpPut("{orderId} | Remove Tax From Order")]
        public IActionResult RemoveTaxFromOrder([FromRoute] string orderId)
        {
            if (!System.Guid.TryParse(orderId, out Guid orderIdGuid))
            {
                return BadRequest("Invalid order ID format");
            }
            if (_orderService.RemoveTaxFromOrder(orderIdGuid))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Record not found");
            }
        }

        [HttpGet("{id} | Generate Cheque For Order")]
        public IActionResult GenerateCheque([FromRoute] string id)
        {
            if (!System.Guid.TryParse(id, out Guid orderIdGuid))
            {
                return BadRequest("Invalid order ID format");
            }
            var cheque = _orderService.GenerateCheque(orderIdGuid);
            return Ok(cheque);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder([FromRoute] string id)
        {
            if (!System.Guid.TryParse(id, out Guid orderIdGuid))
            {
                return BadRequest("Invalid order ID format");
            }
            var order = _orderService.GetOrderById(orderIdGuid);
            if (order == null)
            {
                return NotFound();
            }
            _orderService.DeleteOrder(orderIdGuid);
            return NoContent();
        }

        [HttpPut("{id} {payment} | Pay For Order: 1 - Cash, 2 - Card, 3 - Coupon")]
        public IActionResult PayForOrder([FromRoute] string id, [FromRoute] PaymentType payment)
        {
            if (!System.Guid.TryParse(id, out Guid orderIdGuid))
            {
                return BadRequest("Invalid order ID format");
            }
            if (!Enum.IsDefined(typeof(PaymentType), payment) || payment == 0)
            {
                return BadRequest("Invalid payment type");
            }
            var order = _orderService.GetOrderById(orderIdGuid);
            if (order == null)
            {
                return NotFound();
            }
            _orderService.PayForOrder(orderIdGuid, payment);
            return NoContent();
        }

        [HttpPut("{id} {amount} | Add a Tip")]
        public IActionResult AddTipToOrder([FromRoute] string id, [FromRoute] decimal amount)
        {
            if (!System.Guid.TryParse(id, out Guid orderIdGuid))
            {
                return BadRequest("Invalid order ID format");
            }
            if (!_orderService.AddTip(orderIdGuid, amount))
            {
                return BadRequest("Order not paid for");
            }
            else
            {
                return Ok();
            }
        }

        [HttpPut("{id} | Close Order")]
        public IActionResult CloseOrder([FromRoute] string id)
        {
            if (!System.Guid.TryParse(id, out Guid orderIdGuid))
            {
                return BadRequest("Invalid order ID format");
            }
            if(!_orderService.CloseOrder(orderIdGuid))
            {
                return BadRequest("Order not paid for/Order not finished");
            }
            else
            {
                return Ok();
            }
        }
    }
}
