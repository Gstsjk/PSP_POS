using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PSP_PoS.Components.ItemComponent;
using PSP_PoS.Components.ServiceComponent;
using System.Text.Json.Serialization;
using PSP_PoS.Components.OrderComponent;
using PSP_PoS.Components.CategoryComponent;

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

        //Navigation
        [JsonIgnore]
        public List<Order> Orders { get; set; }

        public Customer()
        {

        }

        public Customer(CustomerCreateDto customerCreateDto)
        {
            Name = customerCreateDto.Name;
            Surname = customerCreateDto.Surname;
            Email = customerCreateDto.Email;
            Password = customerCreateDto.Password;
        }
        public void UpdateCustomer(CustomerCreateDto customerCreateDto)
        {
            Name = customerCreateDto.Name;
            Surname = customerCreateDto.Surname;
            Surname = customerCreateDto.Email;
            Email = customerCreateDto.Email;
            Password = customerCreateDto.Password;
        }
    }
}
