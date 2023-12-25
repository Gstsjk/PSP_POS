using PSP_PoS.Components.CustomerComponent;
using PSP_PoS.Components.EmployeeComponent;
using PSP_PoS.Components.TaxComponent;
using PSP_PoS.Data;

namespace PSP_PoS.Components.EmployeeComponent
{
    public class EmployeeService : IEmployeeService
    {
        private readonly DataContext _context;

        public EmployeeService(DataContext context)
        {
            _context = context;
        }

        public List<EmployeeWithIdDto> GetEmployees()
        {
            var employees = _context.Employees.ToList();
            List<EmployeeWithIdDto> employeeWithIdDtos = employees.Select(e => new EmployeeWithIdDto(e)).ToList();
            return employeeWithIdDtos;
        }

        public EmployeeWithIdDto? GetEmployeeById(Guid id)
        {
            Employee? employee = _context.Employees.Find(id);

            if (employee == null)
            {
                return null;
            }
            EmployeeWithIdDto employeeWithIdDto = new EmployeeWithIdDto(employee);
            return employeeWithIdDto;
        }

        public Employee AddEmployee(EmployeeDto employeeDto)
        {
            Employee employee = new Employee(employeeDto);
            _context.Employees.Add(employee);
            _context.SaveChanges();

            return employee;
        }

        public bool UpdateEmployee(EmployeeDto employeeDto, Guid id)
        {
            Employee? employee = _context.Employees.Find(id);

            if (employee == null)
            {
                return false;
            }

            employee.UpdateEmployee(employeeDto);

            _context.Employees.Update(employee);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteEmployee(Guid id)
        {
            Employee? employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return false;
            }

            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return true;
        }
    }
}
