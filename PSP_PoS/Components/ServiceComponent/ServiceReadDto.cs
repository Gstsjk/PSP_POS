using PSP_PoS.Components.CategoryComponent;
using PSP_PoS.Components.DiscountComponent;

namespace PSP_PoS.Components.ServiceComponent
{
    public class ServiceReadDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Duration { get; set; }

        public decimal Price { get; set; }

        public Category Category { get; set; }

        public Discount? Discount { get; set; }

        public ServiceReadDto(Service service)
        {
            Id = service.Id;
            Name = service.Name;
            Description = service.Description;
            Duration = service.Duration;
            Price = service.Price;
            Category = service.Category;
            Discount = service.Discount;
            
        }
    }
}
