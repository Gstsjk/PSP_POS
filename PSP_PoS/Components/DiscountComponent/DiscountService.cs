using PSP_PoS.Data;
using System.Reflection.Metadata.Ecma335;

namespace PSP_PoS.Components.DiscountComponent
{
    public class DiscountService : IDiscountService
    {
        private readonly DataContext _context;

        public DiscountService(DataContext context)
        {
            _context = context;
        }

        public List<DiscountReadDto> GetAllDiscounts()
        {
            List<Discount> discounts = _context.Discounts.ToList();
            List<DiscountReadDto> discountReadDtos = new List<DiscountReadDto>();

            foreach (var discount in discounts) 
            {
                DiscountReadDto discountReadDto = new DiscountReadDto(discount);
                discountReadDtos.Add(discountReadDto);
            }
            return discountReadDtos;
        }
        public Discount GetDiscountById(Guid discountId)
        {
            return _context.Discounts.FirstOrDefault(t => t.Id == discountId)!;
        }

        public Discount AddDiscount(DiscountCreateDto discountCreateDto)
        {
            Discount discount = new Discount(discountCreateDto);
            _context.Discounts.Add(discount);
            _context.SaveChanges();
            return discount;
        }
        public bool UpdateDiscount(DiscountCreateDto discountCreateDto, Guid id)
        {
            Discount? discount = _context.Discounts.Find(id);
            if (discount == null)
            {
                return false;
            }
            discount.DiscountType = discountCreateDto.DiscountType;
            discount.Percentage = discountCreateDto.Percentage;

            _context.Discounts.Update(discount);
            _context.SaveChanges();
            return true;
        }
        public void DeleteDiscount(Guid discountId)
        {
            var discount = _context.Discounts.FirstOrDefault(t => t.Id == discountId);
            if (discount != null)
            {
                _context.Discounts.Remove(discount);
                _context.SaveChanges();
            }
        }
    }
}
