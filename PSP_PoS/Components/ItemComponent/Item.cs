using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PSP_PoS.Enums;

namespace PSP_PoS.Components.ItemComponent
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }

        [ForeignKey("Discount")]
        public Guid DiscountId { get; set; }

        public Item()
        {

        }

        public Item(ItemDto itemDto)
        {
            Name = itemDto.Name;
            if (itemDto.Description != null)
            {
                Description = itemDto.Description;
            }
            Price = itemDto.Price;
            Stock = itemDto.Stock;
            CategoryId = itemDto.CategoryId;
            if (itemDto.DiscountId != null)
            {
                DiscountId = itemDto.DiscountId.Value;

            }
        }

        public void UpdateItem(ItemDto itemDto)
        {
            Name = itemDto.Name;
            if (itemDto.Description != null)
            {
                Description = itemDto.Description;
            }
            Price = itemDto.Price;
            Stock = itemDto.Stock;
            CategoryId = itemDto.CategoryId;
            if (itemDto.DiscountId != null)
            {
                DiscountId = itemDto.DiscountId.Value;

            }
        }
    }
}
