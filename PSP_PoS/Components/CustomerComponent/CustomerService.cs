using PSP_PoS.Components.CategoryComponent;
using PSP_PoS.Data;

namespace PSP_PoS.Components.CustomerComponent
{
    public class CustomerService : ICustomerService
    {
        private readonly DataContext _context;

        public CustomerService(DataContext context)
        {
            _context = context;
        }

        public List<CustomerReadDto> GetAllCustomers()
        {
            List<Customer> customers = _context.Customers.ToList();
            List<CustomerReadDto> customerReadDtos = new List<CustomerReadDto>();

            foreach (var customer in customers)
            {
                CustomerReadDto customerReadDto = new CustomerReadDto(customer);
                customerReadDtos.Add(customerReadDto);
            }
            return customerReadDtos;
        }

        public Customer GetCustomerById(Guid customerId)
        {
            return _context.Customers.FirstOrDefault(t => t.Id == customerId)!;
        }

        public Customer AddCustomer(CustomerCreateDto customerCreateDto)
        {
            Customer customer = new Customer(customerCreateDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }
        public bool UpdateCustomer(CustomerCreateDto customerCreateDto, Guid id)
        {
            Customer? customer = _context.Customers.Find(id);
            if(customer == null)
            {
                return false;
            }
            customer.UpdateCustomer(customerCreateDto);
            _context.SaveChanges();
            return true;
        }
        public void DeleteCustomer(Guid customerId)
        {
            var customer = _context.Customers.FirstOrDefault(t => t.Id == customerId);
            if(customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
        }
    }
}
