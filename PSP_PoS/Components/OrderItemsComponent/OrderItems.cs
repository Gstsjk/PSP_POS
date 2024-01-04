using PSP_PoS.Components.ItemComponent;
using PSP_PoS.Components.OrderComponent;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PSP_PoS.Components.ItemOrderComponent
{
    public class OrderItems
    {
        [Key]
        [Required]
        public Guid OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        [Key]
        [Required]
        public Guid ItemId { get; set; }

        [ForeignKey("ItemId")]
        public Item Item { get; set; }

        public int Quantity { get; set; }

        public OrderItems()
        {
            
        }

        public OrderItems(Guid orderId, Guid itemId, int quantity)
        {
            OrderId = orderId;
            ItemId = itemId;
            Quantity = quantity;

        }
    }
}
