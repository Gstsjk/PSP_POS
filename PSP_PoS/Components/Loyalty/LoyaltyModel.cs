using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PSP_PoS.Components.Loyalty
{
    public class LoyaltyModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [ForeignKey("CustomerModel")]
        public Guid CustomerId { get; set; }
        public int Points { get; set; } // changed because easier to work with ints
    }
}
