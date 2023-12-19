namespace PSP_PoS.Components.Discount
{
    public class DiscountModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int Percentage { get; set; } // 0 - 100 %
        public DateTime? Start {  get; set; }
        public DateTime? End {  get; set; }
        public int Amount { get; set; } // in cents from item
    }
}
