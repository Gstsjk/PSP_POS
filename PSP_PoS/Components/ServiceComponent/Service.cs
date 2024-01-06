using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PSP_PoS.Components.DiscountComponent;
using PSP_PoS.Enums;
using PSP_PoS.Components.CategoryComponent;

namespace PSP_PoS.Components.ServiceComponent
{
    public class Service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public string? Description { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public decimal Price { get; set; }

        //Navigation

        [Required]
        public Guid CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public Guid? DiscountId { get; set; }

        [ForeignKey("DiscountId")]
        public Discount? Discount { get; set; }


        public Service()
        { 

        }

        public Service(ServiceCreateDto serviceCreateDto)
        {
            Name = serviceCreateDto.Name;
            Description = serviceCreateDto.Description;
            Duration = serviceCreateDto.Duration;
            Price = serviceCreateDto.Price;
            CategoryId = serviceCreateDto.CategoryId;
        }

        public void UpdateService(ServiceCreateDto serviceCreateDto)
        {
            Name = serviceCreateDto.Name;
            Description = serviceCreateDto.Description;
            Duration = serviceCreateDto.Duration;
            Price = serviceCreateDto.Price;
            CategoryId = serviceCreateDto.CategoryId;
        }
    }
}
