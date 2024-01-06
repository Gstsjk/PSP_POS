using PSP_PoS.Components.ItemComponent;
using PSP_PoS.Components.OrderComponent;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PSP_PoS.Components.ServiceComponent;

namespace PSP_PoS.Components.OrderService
{
    public class OrderServices
    {
        [Required]
        public Guid OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        [Required]
        public Guid ServiceId { get; set; }

        [ForeignKey("ServiceId")]
        public Service Service { get; set; }

        public int Quantity { get; set; }


        public OrderServices()
        {

        }

        public OrderServices(Guid orderId, Guid serviceId, int quantity)
        {
            OrderId = orderId;
            ServiceId = serviceId;
            Quantity = quantity;
        }
    }
}
