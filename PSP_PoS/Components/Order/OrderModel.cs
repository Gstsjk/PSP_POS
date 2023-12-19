using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSP_PoS.Components.Order
{
    public class OrderModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [ForeignKey("CustomerModel")]
        public Guid CustomerId { get; set; }
        [ForeignKey("EmplyeeModel")]
        public Guid EmployeeId { get; set; }
        public DateTime? Date { get; set; }
        public int OrderStatus { get; set; }
        public int OrderType { get; set; }
        public int TotalPrice { get; set; } // in cents
    }
}
