using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PSP_PoS.Enums;

namespace PSP_PoS.Components.Product
{
    public class ItemModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        [ForeignKey("CategoryModel")]
        public Guid CategoryId { get; set; }

        [ForeignKey("DiscountModel")]
        public Guid DiscountId { get; set; }
    }
}
