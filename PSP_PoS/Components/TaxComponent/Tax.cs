using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PSP_PoS.Components.OrderComponent;
using System.Text.Json.Serialization;

namespace PSP_PoS.Components.TaxComponent
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

        //Navigation
        [JsonIgnore]
        public List<Order> Orders { get; set;  }

        public Tax()
        {
            
        }

        public Tax(TaxCreateDto taxCreateDto)
        {
            Name = taxCreateDto.Name;
            Rate = taxCreateDto.Rate;
        }
    }
}
