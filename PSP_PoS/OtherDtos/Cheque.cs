using PSP_PoS.Components.ItemComponent;
using PSP_PoS.Components.ItemOrderComponent;
using PSP_PoS.Components.OrderComponent;
using PSP_PoS.Components.OrderItemsComponent;
using PSP_PoS.Components.OrderService;
using PSP_PoS.Components.ServiceComponent;

namespace PSP_PoS.OtherDtos
{
    public class Cheque
    {
        public DateTime Date { get; set; }

        public List<ItemCheque> Items { get; set; }

        public List<ServiceCheque> Services { get; set; }

        public decimal PriceBeforeTax { get; set; }

        public decimal PriceAfterTax { get; set; }

        public int TaxAmount { get; set; }

        public Cheque(Order order, List<ItemCheque> itemCheques, List<ServiceCheque> serviceCheques)
        {
            Date = order.DateCreated;
            Items = itemCheques;
            Services = serviceCheques;
            PriceBeforeTax = 0;
            PriceAfterTax = 0;
            foreach (var item in Items)
            {
                if (item.DiscountPercentage != 0)
                {
                    PriceBeforeTax += item.PriceAfterDiscount * item.Quantity;
                }
                else
                {
                    PriceBeforeTax += item.Price * item.Quantity;
                }
            }
            foreach (var service in Services)
            {
                if (service.DiscountPercentage != 0)
                {
                    PriceBeforeTax += service.PriceAfterDiscount * service.Quantity;
                }
                else
                {
                    PriceBeforeTax += service.Price * service.Quantity;
                }
            }
            if(order.Tax == null)
            {
                TaxAmount = 0;
                PriceAfterTax = PriceBeforeTax;
                
            }
            else
            {
                TaxAmount = order.Tax.Rate;

                decimal taxAmount = TaxAmount;
                PriceAfterTax = Math.Round(PriceBeforeTax * (taxAmount / 100m) + PriceBeforeTax, 2);
            }
            
        }
    }
}
