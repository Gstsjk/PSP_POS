using PSP_PoS.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PSP_PoS.Components.ItemComponent;
using PSP_PoS.Components.ServiceComponent;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace PSP_PoS.Components.CategoryComponent
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        //Navigation
        [JsonIgnore]
        public List<Item> Items { get; set; }
        [JsonIgnore]
        public List<Service> Services { get; set; }

        public Category()
        {
            
        }

        public Category(CategoryCreateDto categoryCreateDto)
        {
            Name = categoryCreateDto.Name;
        }
        
    }
}
