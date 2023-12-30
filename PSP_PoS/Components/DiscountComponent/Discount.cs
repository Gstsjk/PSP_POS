using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PSP_PoS.Enums;
using PSP_PoS.Components.ItemComponent;
using PSP_PoS.Components.ServiceComponent;
using System.Text.Json.Serialization;

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

        //Navigation
        [JsonIgnore]
        public List<Item> Items { get; set; }
        [JsonIgnore]
        public List<Service> Services { get; set; }

        public Discount()
        {

        }

        public Discount(DiscountCreateDto discountCreateDto)
        {
            DiscountType = discountCreateDto.DiscountType;
            Percentage = discountCreateDto.Percentage;
        }

    }
}
