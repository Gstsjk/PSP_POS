using PSP_PoS.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSP_PoS.Components.Order
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; }

        [Required]
        public Status OrderStatus { get; set; }

        public decimal Tip { get; set; }
        
        public PaymentType PaymentType { get; set; }

        [Required]
        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }

        [Required]
        [ForeignKey("Employee")]
        public Guid EmployeeId { get; set; }

        [ForeignKey("TaxModel")]
        public Guid TaxId { get; set; }

        public Order()
        {

        }
    }
}
