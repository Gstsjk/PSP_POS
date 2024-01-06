namespace PSP_PoS.Components.TaxComponent
{
    public class TaxReadDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Rate { get; set; }

        public TaxReadDto(Tax tax)
        {
            Id = tax.Id;
            Name = tax.Name;
            Rate = tax.Rate;
        }
    }
}
