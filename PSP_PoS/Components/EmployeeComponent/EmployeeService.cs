using Microsoft.EntityFrameworkCore;
using PSP_PoS.Components.ItemComponent;
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

        public List<EmployeeReadDto> GetAllEmployees()
        {
            List<Employee> employees = _context.Employees.ToList();
            List<EmployeeReadDto> employeeReadDtos = new List<EmployeeReadDto>();

            foreach(var employee in employees)
            {
                EmployeeReadDto employeeReadDto = new EmployeeReadDto(employee);
                employeeReadDtos.Add(employeeReadDto);
            }
            return employeeReadDtos;
        }
        public EmployeeReadDto GetEmployeeById(Guid employeeId)
        {
            var employee = _context.Employees.FirstOrDefault(t => t.Id == employeeId)!;
            EmployeeReadDto employeeReadDto = new EmployeeReadDto(employee);
            return employeeReadDto;
        }
        public Employee AddEmployee(EmployeeCreateDto employeeCreateDto)
        {
            Employee employee = new Employee(employeeCreateDto);
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;
        }
        public bool UpdateEmployee(EmployeeCreateDto employeeCreateDto, Guid id)
        {
            Employee? employee = _context.Employees.Find(id);
            if(employee == null)
            {
                return false;
            }
            employee.UpdateEmployee(employeeCreateDto);
            _context.SaveChanges();
            return true;
        }
        public void DeleteEmployee(Guid employeeId)
        {
            var employee = _context.Employees.FirstOrDefault(t => t.Id == employeeId);
            if(employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }
    }
}
