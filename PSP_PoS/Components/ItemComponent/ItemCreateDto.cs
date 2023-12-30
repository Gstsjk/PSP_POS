using PSP_PoS.Components.CategoryComponent;
using PSP_PoS.Components.DiscountComponent;
using System.ComponentModel.DataAnnotations;

namespace PSP_PoS.Components.ItemComponent
{
    public class ItemCreateDto
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public Guid CategoryId { get; set; }
    }
}
