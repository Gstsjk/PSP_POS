namespace PSP_PoS.Components.Tax
{
    public class TaxModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int Rate { get; set; } // yaml pvz yra 0.25 tai nezinau kaip konvertuot siuo atveju
    }
}
