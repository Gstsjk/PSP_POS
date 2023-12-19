using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PSP_PoS.Components.Discount
{
    public class DiscountModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int Percentage { get; set; } // 0 - 100 % easier t
        public DateTime? Start {  get; set; }
        public DateTime? End {  get; set; }
        public int Amount { get; set; } // in cents from item
    }
}
