using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PSP_PoS.Components.Service
{
    public class ServiceModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        [ForeignKey("TaxModel")]
        public Guid TaxRate { get; set; }
        public string? Description { get; set; }
        public string? ImageURL { get; set; }
        [ForeignKey("CategoryModel")]
        public Guid CategoryId { get; set; }
        public int Duration { get; set; }
    }
}
