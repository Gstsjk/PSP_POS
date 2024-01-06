using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PSP_PoS.Components.CategoryComponent
{
    public class CategoryReadDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public CategoryReadDto(Category category)
        {
            Id = category.Id;
            Name = category.Name;
        }
    }
}
