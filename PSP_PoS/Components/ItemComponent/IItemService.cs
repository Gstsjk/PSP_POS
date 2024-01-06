namespace PSP_PoS.Components.ItemComponent
{
    public interface IItemService
    {
        List<ItemReadDto> GetAllItems();
        ItemReadDto GetItemById(Guid itemId);
        Item AddItem(ItemCreateDto itemCreateDto);
        bool AddDiscountToItem(Guid itemId, Guid discountId);
        bool UpdateItem(ItemCreateDto itemCreateDto, Guid id);
        void DeleteItem(Guid itemId);
        bool RemoveDiscountFromItem(Guid itemId);
        bool IfCategoryIdValid(Guid id);
        bool IfDiscountIdValid(Guid id);
        bool IfItemIdValid(Guid id);
    }
}
