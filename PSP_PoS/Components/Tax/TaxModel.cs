using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PSP_PoS.Enums;

namespace PSP_PoS.Components.Tax
{
    public class TaxModel
    {
        [Key]
        public TaxType TaxType { get; set; }
        
        [Required]        
        public int Rate { get; set; } // in yaml - 0.25 Changed to int because easier to work
    }
}
