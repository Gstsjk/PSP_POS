using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PSP_PoS.Components.Order;
using PSP_PoS.Components.Item;

namespace PSP_PoS.Components.OrderItem
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
