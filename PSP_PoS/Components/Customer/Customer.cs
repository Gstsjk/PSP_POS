using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PSP_PoS.Components.Customer
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public Customer()
        {

        }
    }

}
