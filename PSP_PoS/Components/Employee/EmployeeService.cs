using PSP_PoS.Components.Account;
using PSP_PoS.Data;

namespace PSP_PoS.Components.Employee
{
    public class EmployeeService : IEmployeeServiceInterface
    {
        DataContext _dataContext;

        public EmployeeService(DataContext context)
        {
            _dataContext = context;
        }

        public bool CreateNewEmployee(EmployeeModel employee)
        {
            // validacija ar viskas ok
            _dataContext.Employees.Add(employee);
            return _dataContext.SaveChanges() == 1 ? true : false;
        }

        public EmployeeModel GetEmployeeById(Guid id)
        {
            return _dataContext.Employees.Find(id);
            //_dataContext.Employees.FirstOrDefault(x => x.Id == id);
        }

        public EmployeeModel GetEmployeeByUsername(string username)
        {
            EmployeeModel employee = _dataContext.Employees.FirstOrDefault(x => x.Username == username);
            if (employee == null)
            {
                return null;
            }

            return employee;
        }

        public bool UpdateEmployee(EmployeeModel employee)
        {
            _dataContext.Employees.Update(employee);
            return _dataContext.SaveChanges() == 1 ? true : false;
        }

        public bool DeleteEmployee(EmployeeModel employee)
        {
            _dataContext.Employees.Remove(employee);
            return _dataContext.SaveChanges() == 1 ? true : false;
        }

    }
}
