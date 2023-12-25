using PSP_PoS.Components.CustomerComponent;
using PSP_PoS.Components.EmployeeComponent;

namespace PSP_PoS.Components.EmployeeComponent
{
    public interface IEmployeeService
    {
        public List<EmployeeWithIdDto> GetEmployees();

        public EmployeeWithIdDto? GetEmployeeById(Guid id);

        public Employee AddEmployee(EmployeeDto employeeDto);

        public bool UpdateEmployee(EmployeeDto employeeDto, Guid id);

        public bool DeleteEmployee(Guid id);
    }
}
