using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PSP_PoS.Components.CustomerComponent
{
    public class CustomerDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public CustomerDto(Customer customer) 
        {
            Name = customer.Name;
            Surname = customer.Surname;
            Email = customer.Email;
            Password = customer.Password;
        }
    }
}
