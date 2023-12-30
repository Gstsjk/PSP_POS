using PSP_PoS.Components.CategoryComponent;
using PSP_PoS.Components.DiscountComponent;

namespace PSP_PoS.Components.ServiceComponent
{
    public class ServiceCreateDto
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public int Duration { get; set; }

        public decimal Price { get; set; }

        public Guid CategoryId { get; set; }
    }
}
