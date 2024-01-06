using System.ComponentModel.DataAnnotations;

namespace PSP_PoS.Components.TaxComponent
{
    public class TaxCreateDto
    {
        public string Name { get; set; }

        public int Rate { get; set; }
    }
}
