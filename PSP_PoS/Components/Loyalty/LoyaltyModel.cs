namespace PSP_PoS.Components.Loyalty
{
    public class LoyaltyModel
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public int Points { get; set; }
    }
}
