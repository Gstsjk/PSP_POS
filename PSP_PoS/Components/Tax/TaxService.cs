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

        public List<TaxModel> GetAllTaxes()
        {
            return _context.Taxes.ToList();
        }

        public TaxModel GetTaxById(Guid taxId)
        {
            return _context.Taxes.FirstOrDefault(t => t.Id == taxId);
        }

        public void AddTax(TaxModel tax)
        {
            _context.Taxes.Add(tax);
            _context.SaveChanges();
        }

        public void UpdateTax(TaxModel tax)
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
