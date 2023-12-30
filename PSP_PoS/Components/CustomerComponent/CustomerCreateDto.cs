using System.ComponentModel.DataAnnotations;

namespace PSP_PoS.Components.CustomerComponent
{
    public class CustomerCreateDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

    }
}
