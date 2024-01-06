using PSP_PoS.Components.CategoryComponent;
using PSP_PoS.Components.DiscountComponent;

namespace PSP_PoS.Components.ItemComponent
{
    public class ItemReadDto
    {

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public Category Category { get; set; }

        public Discount? Discount { get; set; }

        public ItemReadDto(Item item)
        {
            Id = item.Id;
            Name = item.Name;
            Description = item.Description;
            Price = item.Price;
            Stock = item.Stock;
            Category = item.Category;
            Discount = item.Discount;
        }

      
    }
}
