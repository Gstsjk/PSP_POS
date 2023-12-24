using Microsoft.AspNetCore.Mvc;
using PSP_PoS.Data;

namespace PSP_PoS.Components.DiscountComponent
{
    public class DiscountService : IDiscountService
    {
        private readonly DataContext _context;

        public DiscountService(DataContext context)
        {
            _context = context;
        }

        public List<Discount> GetDiscounts()
        {
            return _context.Discounts.Where(x => true).ToList();
        }

        public Discount? GetDiscountById(Guid id)
        {
            Discount? discount = _context.Discounts.Find(id);

            if(discount == null)
            {
                return null;
            }

            return discount;
        }
        
        public Discount AddDiscount(DiscountDto discountDto)
        {
            Discount discount = new Discount(discountDto);
            _context.Discounts.Add(discount);
            _context.SaveChanges();
            
            return discount;
        }

        public bool UpdateDiscount(DiscountDto discountDto, Guid id)
        {
            Discount? discount = _context.Discounts.Find(id);

            if (discount == null)
            {
                return false;
            }

            discount.Percentage = discountDto.Percentage;
            discount.DiscountType = discountDto.DiscountType;

            _context.Discounts.Update(discount);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteDiscount(Guid id)
        {
            Discount? discount = _context.Discounts.Find(id);
            if (discount == null)
            {
                return false;
            }

            _context.Discounts.Remove(discount);
            _context.SaveChanges();
            return true;
        }

    }
}
