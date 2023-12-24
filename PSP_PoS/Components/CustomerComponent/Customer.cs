using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PSP_PoS.Components.CategoryComponent;
using PSP_PoS.Components.DiscountComponent;
using PSP_PoS.Components.ItemComponent;
using Microsoft.EntityFrameworkCore;

namespace PSP_PoS.Components.CustomerComponent
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public Customer()
        {

        }

        public Customer(CustomerDto customer)
        {
            Name = customer.Name;
            Surname = customer.Surname;
            Email = customer.Email;
            Password = customer.Password;
        }

        public void UpdateCustomer(CustomerDto customerDto)
        {
            Name = customerDto.Name;
            Surname = customerDto.Surname;
            Email = customerDto.Email;
            Password = customerDto.Password;
        }
    }
}
