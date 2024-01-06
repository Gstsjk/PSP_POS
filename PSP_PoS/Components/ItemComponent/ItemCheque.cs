namespace PSP_PoS.Components.ItemComponent
{
    public class ItemCheque
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int DiscountPercentage { get; set; }

        public decimal PriceAfterDiscount {  get; set; }

        public int Quantity { get; set; }
    }
}
