namespace PSP_PoS.Components.Account
{
    public class AccountModel
    {
        public Guid Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public int Privileges { get; set; }
    }
}
