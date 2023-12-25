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

        public List<Tax> GetAllTaxes()
        {
            return _context.Taxes.ToList();
        }

        public Tax? GetTaxById(Guid taxId)
        {
            return _context.Taxes.FirstOrDefault(t => t.Id == taxId);
        }

        public Tax AddTax(TaxDto taxDto)
        {
            Tax tax = new Tax(taxDto);
            _context.Taxes.Add(tax);
            _context.SaveChanges();
            return tax;
        }

        public bool UpdateTax(TaxDto taxDto, Guid id)
        {
            Tax? tax = _context.Taxes.Find(id);

            if(tax == null)
            {
                return false;
            }
            tax.Name = taxDto.Name;
            tax.Rate = taxDto.Rate;

            _context.Taxes.Update(tax);
            _context.SaveChanges();
            return true;
        }

        public void DeleteTax(Guid taxId)
        {
            var tax = _context.Taxes.FirstOrDefault(t => t.Id == taxId);

            if (tax != null)
            {
                _context.Taxes.Remove(tax);
                _context.SaveChanges();
            }
        }
    }
}
