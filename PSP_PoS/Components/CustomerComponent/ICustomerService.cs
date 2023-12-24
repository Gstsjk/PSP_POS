using Microsoft.EntityFrameworkCore;

namespace PSP_PoS.Components.CustomerComponent
{
    public interface ICustomerService
    {
        public List<Customer> GetCustomers();

        public Customer? GetCustomerById(Guid id);

        public Customer? GetCustomerByEmail(string email);

        public Customer AddCustomer(CustomerDto customerDto);

        public bool UpdateCustomer(CustomerDto customerDto, Guid id);

        public bool DeleteCustomer(Guid id);
    }
}
