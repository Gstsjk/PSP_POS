using Microsoft.EntityFrameworkCore;
using PSP_PoS.Components.CategoryComponent;
using PSP_PoS.Components.DiscountComponent;
using PSP_PoS.Data;

namespace PSP_PoS.Components.ItemComponent
{
    public class ItemService : IItemService
    {
        private readonly DataContext _context;

        public ItemService(DataContext context)
        {
            _context = context;
        }

        public List<ItemReadDto> GetAllItems()
        {
            List<Item> items = _context.Items.
                Include(item => item.Category).
                Include(item => item.Discount).
                ToList();

            List<ItemReadDto> itemReadDtos = new List<ItemReadDto>();

            foreach (var item in items)
            {
                ItemReadDto itemReadDto = new ItemReadDto(item);
                itemReadDtos.Add(itemReadDto);
            }
            return itemReadDtos;
        }
        public ItemReadDto GetItemById(Guid itemId)
        {
            var item = _context.Items.
                Include(t => t.Category).
                Include(t => t.Discount).
                FirstOrDefault(t => t.Id == itemId)!;

            ItemReadDto itemReadDto = new ItemReadDto(item);
            return itemReadDto;
        }
        public Item AddItem(ItemCreateDto itemCreateDto)
        {
            Item item = new Item(itemCreateDto);
            item.Category = _context.Categories.Find(item.CategoryId)!;
            _context.Items.Add(item);
            _context.SaveChanges();
            return item;
        }

        public bool AddDiscountToItem(Guid itemId, Guid discountId)
        {
            Item? item = GetItemByIdModel(itemId);
            item.DiscountId = discountId;
            item.Discount = _context.Discounts.Find(discountId);
            _context.Items.Update(item);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateItem(ItemCreateDto itemCreateDto, Guid id)
        {
            Item? item = _context.Items.FirstOrDefault(t => t.Id == id)!;

            if (item == null)
            {
                return false;
            }
            item.UpdateItem(itemCreateDto);
            _context.Items.Update(item);
            _context.SaveChanges();
            return true;
        }
        public void DeleteItem(Guid itemId)
        {
            Item item = _context.Items.FirstOrDefault(t =>t.Id == itemId)!; 
            if(item != null)
            {
                _context.Items.Remove(item);
                _context.SaveChanges();
            }
        }

        public bool RemoveDiscountFromItem(Guid itemId)
        {
            Item? item = GetItemByIdModel(itemId);
            item.DiscountId = null;
            item.Discount = null;
            _context.Items.Update(item);
            _context.SaveChanges();
            return true;
        }
        public bool IfCategoryIdValid(Guid id)
        {
            var category = _context.Categories.Find(id);
            if(category != null)
            {
                return true;
            }
            else 
            { 
                return false;
            }
        }
        public bool IfDiscountIdValid(Guid id)
        {
            var discount = _context.Discounts.Find(id);
            if (discount != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IfItemIdValid(Guid id)
        {
            var item = _context.Items.Find(id);
            if (item != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Item GetItemByIdModel(Guid itemId)
        {
            return _context.Items.
                Include(t => t.Category).
                Include(t => t.Discount).
                FirstOrDefault(t => t.Id == itemId)!;

        }
    }
}
