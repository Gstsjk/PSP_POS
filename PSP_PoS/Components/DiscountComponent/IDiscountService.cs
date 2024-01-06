namespace PSP_PoS.Components.DiscountComponent
{
    public interface IDiscountService
    {
        List<DiscountReadDto> GetAllDiscounts();
        Discount GetDiscountById(Guid discountId);
        Discount AddDiscount(DiscountCreateDto discountCreateDto);
        bool UpdateDiscount(DiscountCreateDto discountCreateDto, Guid id);
        void DeleteDiscount(Guid discountId);
    }
}
