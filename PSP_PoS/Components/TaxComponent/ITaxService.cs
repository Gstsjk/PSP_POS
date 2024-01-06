namespace PSP_PoS.Components.TaxComponent
{
    public interface ITaxService
    {
        List<TaxReadDto> GetAllTaxes();
        TaxReadDto GetTaxById(Guid taxId);
        Tax AddTax(TaxCreateDto taxCreateDto);
        bool UpdateTax(TaxCreateDto taxCreateDto, Guid id);
        void DeleteTax(Guid taxId);
    }
}
