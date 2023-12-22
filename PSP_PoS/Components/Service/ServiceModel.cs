using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PSP_PoS.Components.Account;
using PSP_PoS.Components.Customer;
using PSP_PoS.Components.Discount;
using PSP_PoS.Components.Tax;
using PSP_PoS.Enums;

namespace PSP_PoS.Components.Service
{
    public class ServiceModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("CustomerModel")]
        public Guid CustomerId { get; set; }

        [ForeignKey("EmployeeModel")]
        public Guid EmployeeId { get; set; }
        public DateTime? Date { get; set; }
        public Status ServiceStatus { get; set; }

        public TimeSpan Duration { get; set; }

        public string Location { get; set; }

        public decimal Price { get; set; }

        [ForeignKey("TaxModel")]
        public TaxType Tax { get; set; }

        public decimal? Tip { get; set; }

        [ForeignKey("DiscountModel")]
        public DiscountType? Discount { get; set; }

        public decimal? FinalPrice { get; set; }

        public PaymentType? PaymentType { get; set; }
    }
}
