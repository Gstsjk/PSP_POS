namespace PSP_PoS.Components.CustomerComponent
{
    public class CustomerReadDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public CustomerReadDto(Customer customer)
        {
            Id = customer.Id;
            Name = customer.Name;
            Surname = customer.Surname;
            Email = customer.Email;
            Password = customer.Password;
        }
    }
}
