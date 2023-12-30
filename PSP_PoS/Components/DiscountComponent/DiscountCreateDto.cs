using PSP_PoS.Enums;
using System.ComponentModel.DataAnnotations;

namespace PSP_PoS.Components.DiscountComponent
{
    public class DiscountCreateDto
    {
        public DiscountType DiscountType { get; set; }

        public int Percentage { get; set; }
    }
}
