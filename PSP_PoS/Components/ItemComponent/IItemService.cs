using PSP_PoS.Components.DiscountComponent;

namespace PSP_PoS.Components.ItemComponent
{
    public interface IItemService 
    {
        public Item AddItem(ItemDto itemDto);

        public List<Item> GetItems();

        public Item? GetItemById(Guid id);

        public bool UpdateItem(ItemDto itemDto, Guid id);

        public bool UpdateItemDiscount(Guid? discountId, Guid id);

        public bool DeleteItem(Guid id);
    }
}
