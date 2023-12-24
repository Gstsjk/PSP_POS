using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PSP_PoS.Components.DiscountComponent;

namespace PSP_PoS.Components.ItemComponent
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpPost]
        public IActionResult AddItem([FromBody] ItemDto itemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Item item = _itemService.AddItem(itemDto);

            return CreatedAtAction(nameof(AddItem), item);
        }


        [HttpGet("{id}")]
        public IActionResult GetItemById([FromRoute] string id)
        {
            if (!System.Guid.TryParse(id, out var taxId))
            {
                return BadRequest("Invalid tax ID format");
            }

            var item = _itemService.GetItemById(taxId);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpGet]
        public IActionResult GetItems()
        {
            var items = _itemService.GetItems();
            return Ok(items);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateItem([FromRoute] string id, [FromBody] ItemDto itemDto)
        {
            if (!System.Guid.TryParse(id, out var itemId))
            {
                return BadRequest("Invalid tax ID format");
            }

            if (_itemService.UpdateItem(itemDto, itemId))
            {
                return StatusCode(201);
                //return Ok();
            }
            else
            {
                return BadRequest("Record not found.");
            }
        }

        [HttpPut("{id}/updateDiscount/{discountId}")]
        public IActionResult UpdateItemDiscount([FromRoute] string discountId, [FromRoute] string id)
        {
            if (!System.Guid.TryParse(id, out var itemId))
            {
                return BadRequest("Invalid tax ID format");
            }

            if (!System.Guid.TryParse(discountId, out var discountIdAsGuid))
            {
                return BadRequest("Invalid tax ID format");
            }

            if (_itemService.UpdateItemDiscount(discountIdAsGuid, itemId))
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
        public IActionResult DeleteItem([FromRoute] string id)
        {
            if (!System.Guid.TryParse(id, out var itemId))
            {
                return BadRequest("Invalid tax ID format");
            }


            if (_itemService.DeleteItem(itemId))
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
