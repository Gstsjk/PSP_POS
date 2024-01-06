using PSP_PoS.Components.CategoryComponent;

namespace PSP_PoS.Components.CustomerComponent
{
    public interface ICustomerService
    {
        List<CustomerReadDto> GetAllCustomers();
        Customer GetCustomerById(Guid customerId);
        Customer AddCustomer(CustomerCreateDto customerCreateDto);
        bool UpdateCustomer(CustomerCreateDto customerCreateDto, Guid id);
        void DeleteCustomer(Guid customerId);
    }
}
