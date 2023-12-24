namespace PSP_PoS.Components.DiscountComponent
{
    public interface IDiscountService
    {
        public Discount AddDiscount(DiscountDto discountDto);

        public List<Discount> GetDiscounts();

        public Discount? GetDiscountById(Guid id);

        public bool UpdateDiscount(DiscountDto discountDto, Guid id);

        public bool DeleteDiscount(Guid id);
    }
}
