using Microsoft.AspNetCore.Mvc;
using PSP_PoS.Components.CategoryComponent;

namespace PSP_PoS.Components.ItemComponent
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public ActionResult GetAllItems()
        {
            var itemsReadDto = _itemService.GetAllItems();
            return Ok(itemsReadDto);
        }

        [HttpGet("{id}")]
        public ActionResult GetItemById([FromRoute] string id)
        {
            if (!System.Guid.TryParse(id, out var itemId))
            {
                return BadRequest("Invalid item ID format");
            }
            var item = _itemService.GetItemById(itemId);
            if(item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult AddItem([FromBody] ItemCreateDto itemCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_itemService.IfCategoryIdValid(itemCreateDto.CategoryId))
            {
                return BadRequest("Category ID not found");
            }
            var item = _itemService.AddItem(itemCreateDto);
            return CreatedAtAction(nameof(AddItem), item);
        }

        [HttpPut("{itemId} {discountId} | Add Discount to item")]
        public IActionResult AddDiscountItem([FromRoute] string itemId, [FromRoute] string discountId)
        {
            if (!System.Guid.TryParse(itemId, out Guid itemIdGuid))
            {
                return BadRequest("Invalid item ID format");
            }
            if (!System.Guid.TryParse(discountId, out Guid discountIdGuid))
            {
                return BadRequest("Invalid discount ID format");
            }
            if (!_itemService.IfItemIdValid(itemIdGuid))
            {
                return BadRequest("Item ID not found");
            }
            if (!_itemService.IfDiscountIdValid(discountIdGuid))
            {
                return BadRequest("Category ID not found");
            }
            if (_itemService.AddDiscountToItem(itemIdGuid, discountIdGuid))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Record not found");
            }
        }

        [HttpPut("{itemId} | Remove Discount from item")]
        public IActionResult RemoveDiscountItem([FromRoute] string itemId)
        {
            if (!System.Guid.TryParse(itemId, out Guid itemIdGuid))
            {
                return BadRequest("Invalid item ID format");
            }
            if (!_itemService.IfItemIdValid(itemIdGuid))
            {
                return BadRequest("Item ID not found");
            }

            if (_itemService.RemoveDiscountFromItem(itemIdGuid))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Record not found");
            }
        }


        [HttpPut("{id}")]
        public IActionResult UpdateItem([FromRoute] string id, [FromBody] ItemCreateDto itemCreateDto)
        {
            if (!System.Guid.TryParse(id, out var itemId))
            {
                return BadRequest("Invalid item ID format");
            }

            if (_itemService.UpdateItem(itemCreateDto, itemId))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Record not found");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteItem([FromRoute] string id)
        {
            if (!System.Guid.TryParse(id, out var itemId))
            {
                return BadRequest("Invalid item ID format");
            }
            var item = _itemService.GetItemById(itemId);
            if (item == null)
            {
                return NotFound();
            }
            _itemService.DeleteItem(itemId);
            return NoContent();
        }

    }
}
