using PSP_PoS.Components.CategoryComponent;
using PSP_PoS.Components.DiscountComponent;
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

        public List<Customer> GetCustomers()
        {
            return _context.Customers.Where(x => true).ToList();
        }

        public Customer? GetCustomerById(Guid id)
        {
            Customer? customer = _context.Customers.Find(id);

            if (customer == null)
            {
                return null;
            }

            return customer;
        }

        public Customer? GetCustomerByEmail(string email)
        {
            Customer? customer = _context.Customers.FirstOrDefault(x => x.Email == email);

            if (customer == null)
            {
                return null;
            }

            return customer;
        }

        public Customer AddCustomer(CustomerDto customerDto)
        {
            Customer customer = new Customer(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;
        }

        public bool UpdateCustomer(CustomerDto customerDto, Guid id)
        {
            Customer? customer = _context.Customers.Find(id);

            if (customer == null)
            {
                return false;
            }

            customer.UpdateCustomer(customerDto);

            _context.Customers.Update(customer);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteCustomer(Guid id)
        {
            Customer? customer = _context.Customers.Find(id);
            if (customer == null)
            {
                return false;
            }

            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return true;
        }
    }
}
