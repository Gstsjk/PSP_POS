namespace PSP_PoS.Components.ServiceComponent
{
    public interface IServiceService
    {
        List<ServiceReadDto> GetAllServices();
        ServiceReadDto GetServiceById(Guid serviceId);
        Service AddService(ServiceCreateDto serviceCreateDto);
        bool AddDiscountToService(Guid serviceId, Guid discountId);
        bool UpdateService(ServiceCreateDto serviceCreateDto, Guid id);
        void DeleteService(Guid serviceId);
        bool RemoveDiscountFromService(Guid serviceId);
        bool IfCategoryIdValid(Guid id);
        bool IfDiscountIdValid(Guid id);
        bool IfServiceIdValid(Guid id);
    }
}
