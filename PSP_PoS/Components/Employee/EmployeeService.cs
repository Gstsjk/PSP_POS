using PSP_PoS.Components.Employee;
using PSP_PoS.Components.Tax;
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

        public bool CreateNewEmployee(Employee employee)
        {
            // validacija ar viskas ok
            _dataContext.Employees.Add(employee);
            return _dataContext.SaveChanges() == 1 ? true : false;
        }

        public Employee GetEmployeeById(Guid id)
        {
            return _dataContext.Employees.Find(id);
            //_dataContext.Employees.FirstOrDefault(x => x.Id == id);
        }

        public Employee GetEmployeeByUsername(string username)
        {
            Employee employee = _dataContext.Employees.FirstOrDefault(x => x.Username == username);
            if (employee == null)
            {
                return null;
            }

            return employee;
        }

        public bool UpdateEmployee(Employee employee)
        {
            _dataContext.Employees.Update(employee);
            return _dataContext.SaveChanges() == 1 ? true : false;
        }

        public bool DeleteEmployee(Employee employee)
        {
            _dataContext.Employees.Remove(employee);
            return _dataContext.SaveChanges() == 1 ? true : false;
        }

    }
}
