using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PSP_PoS.Components.OrderComponent;
using PSP_PoS.Components.ItemComponent;

namespace PSP_PoS.Components.OrderItemComponent
{
    public class OrderItem
    {
        [Key]
        [Required]
        [ForeignKey("Order")]
        public Guid OrderId { get; set; }

        [Key]
        [Required]
        [ForeignKey("Item")]
        public Guid ItemId { get; set; }

        [Required]
        public int Quantity { get; set; }

        public DateTime StartTime { get; set; }

        public OrderItem() { }
    }
}
