using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PSP_PoS.Enums;
using System.Text.Json.Serialization;

namespace PSP_PoS.Components.Tax
{
    public class Tax
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]        
        public int Rate { get; set; }


        public Tax()
        {

        }
        public Tax(TaxDto taxDto)
        {
            Name = taxDto.Name;
            Rate = taxDto.Rate;
        }
    }
}
