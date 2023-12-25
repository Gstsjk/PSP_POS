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

        public List<Item> GetItems()
        {
            return _context.Items.Where(x => true).ToList();
        }

        public Item? GetItemById(Guid id)
        {
            Item? item = _context.Items.Find(id);

            if (item == null)
            {
                return null;
            }

            return item;
        }

        public Item AddItem(ItemDto itemDto)
        {
            Item item = new Item(itemDto);
            _context.Items.Add(item);
            _context.SaveChanges();

            return item;
        }

        public bool UpdateItemDiscount(Guid? discountId, Guid id)
        {
            Item? item = _context.Items.Find(id);

            Discount? discount = _context.Discounts.Find(discountId);
            if (discount == null)
            {
                return false;
            }
            
            if (item == null || discountId == null)
            {
                return false;
            }

            item.DiscountId = discountId.Value;

            _context.Items.Update(item);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteItem(Guid id)
        {
            Item? item = _context.Items.Find(id);
            if (item == null)
            {
                return false;
            }

            _context.Items.Remove(item);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateItem(ItemDto itemDto, Guid id)
        {
            Item? item = _context.Items.Find(id);

            if (item == null)
            {
                return false;
            }

            item.UpdateItem(itemDto);
            
            _context.Items.Update(item);
            _context.SaveChanges();
            return true;
        }     
    }
}
