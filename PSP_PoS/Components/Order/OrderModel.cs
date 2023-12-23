using PSP_PoS.Components.Account;
using PSP_PoS.Components.Customer;
using PSP_PoS.Components.Discount;
using PSP_PoS.Components.Tax;
using PSP_PoS.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSP_PoS.Components.Order
{
    public class OrderModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; }
        public Status OrderStatus { get; set; }
        public decimal Tip { get; set; }
        public PaymentType PaymentType { get; set; }

        [ForeignKey("CustomerModel")]
        public Guid CustomerId { get; set; }

        [ForeignKey("EmployeeModel")]
        public Guid EmployeeId { get; set; }

        [ForeignKey("TaxModel")]
        public Guid TaxId { get; set; }
    }
}
