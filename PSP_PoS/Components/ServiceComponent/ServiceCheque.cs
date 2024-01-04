using PSP_PoS.OtherDtos;

namespace PSP_PoS.Components.ServiceComponent
{
    public class ServiceCheque
    {
        public string Name { get; set; }

        public TimeDto Duration {  get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
