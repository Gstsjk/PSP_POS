namespace PSP_PoS.Components.Service
{
    public class ServiceModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        public Guid TaxRate { get; set; }
        public string? Description { get; set; }
        public string? ImageURL { get; set; }
        public Guid CategoryId { get; set; }
        public int Duration { get; set; }
    }
}
