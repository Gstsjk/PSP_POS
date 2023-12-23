using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PSP_PoS.Components.Order;
using PSP_PoS.Components.Product;

namespace PSP_PoS.Components.OrderProduct
{
    public class OrderItemModel
    {
        [Key]
        [Required]
        [ForeignKey("OrderModel")]
        public Guid OrderId { get; set; }

        [Key]
        [Required]
        [ForeignKey("ItemModel")]
        public Guid ItemId { get; set; }

        [Required]
        public int Quantity { get; set; }

        public DateTime StartTime { get; set; }
    }
}
