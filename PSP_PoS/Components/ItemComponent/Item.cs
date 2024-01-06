using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PSP_PoS.Enums;
using PSP_PoS.Components.DiscountComponent;
using PSP_PoS.Components.CategoryComponent;
namespace PSP_PoS.Components.ItemComponent
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Stock { get; set; }

        //Navigation

        [Required]
        public Guid CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        
        public Guid? DiscountId { get; set; }

        [ForeignKey("DiscountId")]
        public Discount? Discount { get; set; }

        public Item()
        {

        }

        public Item(ItemCreateDto itemCreateDto)
        {
            Name = itemCreateDto.Name;
            Description = itemCreateDto.Description;
            Price = itemCreateDto.Price;
            Stock = itemCreateDto.Stock;
            CategoryId = itemCreateDto.CategoryId;
        }

        public void UpdateItem(ItemCreateDto itemCreateDto)
        {
            Name = itemCreateDto.Name;
            Description = itemCreateDto.Description;
            Price = itemCreateDto.Price;
            Stock = itemCreateDto.Stock;
            CategoryId = itemCreateDto.CategoryId;
        }
    }
}
