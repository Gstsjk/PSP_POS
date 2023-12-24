namespace PSP_PoS.Components.Tax
{
    public interface ITaxService
    {
        List<Tax> GetAllTaxes();
        Tax GetTaxById(Guid taxId);
        void AddTax(Tax tax);
        void UpdateTax(Tax tax);
        void DeleteTax(Guid taxId);
    }
}
