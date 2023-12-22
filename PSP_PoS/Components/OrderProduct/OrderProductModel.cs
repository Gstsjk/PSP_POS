using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PSP_PoS.Components.Order;
using PSP_PoS.Components.Product;

namespace PSP_PoS.Components.OrderProduct
{
    public class OrderProductModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey("OrderModel")]
        public Guid OrderId { get; set; }

        [Required]
        [ForeignKey("ProductModel")]
        public Guid ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
