using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PSP_PoS.Enums;

namespace PSP_PoS.Components.Product
{
    public class ProductModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Ean { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public CategoryType Category { get; set; }
        public int Stock { get; set; }
    }
}
