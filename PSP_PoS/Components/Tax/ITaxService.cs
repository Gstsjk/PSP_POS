namespace PSP_PoS.Components.Tax
{
    public interface ITaxService
    {
        List<TaxModel> GetAllTaxes();
        TaxModel GetTaxById(Guid taxId);
        void AddTax(TaxModel tax);
        void UpdateTax(TaxModel tax);
        void DeleteTax(Guid taxId);
    }
}
