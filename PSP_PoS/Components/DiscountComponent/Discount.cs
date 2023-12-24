using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PSP_PoS.Enums;

namespace PSP_PoS.Components.DiscountComponent
{
    public class Discount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
       
        [Required]
        public DiscountType DiscountType { get; set; }
        
        [Required]
        public int Percentage { get; set; } // 0 - 100 %

        public Discount()
        {

        }

        public Discount(DiscountDto discountDto)
        {
            DiscountType = discountDto.DiscountType;
            Percentage = discountDto.Percentage;
        }
    }
}
