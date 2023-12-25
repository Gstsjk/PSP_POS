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
            var tax = _context.Taxes.FirstOrDefault(_t => _t.Id == id);
            if(tax == null)
            {
                return false;
            }
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
