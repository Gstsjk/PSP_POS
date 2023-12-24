using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PSP_PoS.Components.Employee;
using PSP_PoS.Components.Customer;
using PSP_PoS.Components.Discount;
using PSP_PoS.Components.Tax;
using PSP_PoS.Enums;

namespace PSP_PoS.Components.Service
{
    public class Service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public string Description { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }

        [ForeignKey("Discount")]
        public Guid DiscountId { get; set; }


        public Service() { }
    }
}
