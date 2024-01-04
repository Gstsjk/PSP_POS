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
            
            PriceBeforeTax = Items.Sum(item => item.Price * item.Quantity);
            PriceBeforeTax += Services.Sum(service => service.Price * service.Quantity);
            if(order.Tax == null)
            {
                PriceAfterTax = PriceBeforeTax;
            }
            else
            {
                TaxAmount = order.Tax.Rate;
                PriceAfterTax = PriceBeforeTax * (TaxAmount / 100) + PriceBeforeTax;
            }
            
        }
    }
}
