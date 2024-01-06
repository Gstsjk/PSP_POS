using PSP_PoS.Enums;

namespace PSP_PoS.Components.DiscountComponent
{
    public class DiscountReadDto
    {
        public Guid Id { get; set; }

        public DiscountType DiscountType { get; set; }

        public int Percentage { get; set; }

        public DiscountReadDto(Discount discount)
        {
            Id = discount.Id;
            DiscountType = discount.DiscountType;
            Percentage = discount.Percentage;
        }
    }
}
