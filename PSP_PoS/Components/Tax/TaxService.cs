
using PSP_PoS.Data;

namespace PSP_PoS.Components.Tax
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

        public Tax GetTaxById(Guid taxId)
        {
            return _context.Taxes.FirstOrDefault(t => t.Id == taxId)!;
        }

        public Tax AddTax(TaxDto tax)
        {
            Tax taxModel = new Tax(tax);
            _context.Taxes.Add(taxModel);
            _context.SaveChanges();
            return taxModel;
        }

        public void UpdateTax(Tax tax)
        {
            _context.Taxes.Update(tax);
            _context.SaveChanges();
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
