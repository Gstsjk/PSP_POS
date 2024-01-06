using PSP_PoS.Data;

namespace PSP_PoS.Components.TaxComponent
{
    public class TaxService : ITaxService
    {
        private readonly DataContext _context;

        public TaxService(DataContext context)
        {
            _context = context;
        }

        public List<TaxReadDto> GetAllTaxes()
        {
            List<Tax> taxes = _context.Taxes.ToList();
            List<TaxReadDto> taxReadDtos = new List<TaxReadDto>();

            foreach (var tax in taxes)
            {
                TaxReadDto taxReadDto = new TaxReadDto(tax);
                taxReadDtos.Add(taxReadDto);
            }
            return taxReadDtos;
        }

        public TaxReadDto GetTaxById(Guid taxId)
        {
            var tax = _context.Taxes.FirstOrDefault(t => t.Id == taxId)!;
            TaxReadDto taxReadDto = new TaxReadDto(tax);
            return taxReadDto;
        }

        public Tax AddTax(TaxCreateDto taxCreateDto)
        {
            Tax tax = new Tax(taxCreateDto);
            _context.Taxes.Add(tax);
            _context.SaveChanges();
            return tax;
        }

        public bool UpdateTax(TaxCreateDto taxCreateDto, Guid id)
        {
            Tax? tax = _context.Taxes.Find(id);
            if(tax == null)
            {
                return false;
            }
            tax.Name = taxCreateDto.Name;
            tax.Rate = taxCreateDto.Rate;

            _context.Taxes.Update(tax);
            _context.SaveChanges();
            return true;
        }

        public void DeleteTax(Guid taxId)
        {
            var tax = _context.Taxes.FirstOrDefault(t => t.Id==taxId); 
            if(tax != null)
            {
                _context.Taxes.Remove(tax);
                _context.SaveChanges();
            }
        }
    }
}
