using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PSP_PoS.Enums;

namespace PSP_PoS.Components.Discount
{
    public class DiscountModel
    {
        [Key]
        public DiscountType DiscountType { get; set; }

        [Required]
        public int Percentage { get; set; } // 0 - 100 % easier t
    }
}
