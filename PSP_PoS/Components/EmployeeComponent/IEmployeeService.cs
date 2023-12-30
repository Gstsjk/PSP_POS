namespace PSP_PoS.Components.EmployeeComponent
{
    public interface IEmployeeService
    {
        List<EmployeeReadDto> GetAllEmployees();
        EmployeeReadDto GetEmployeeById(Guid employeeId);
        Employee AddEmployee(EmployeeCreateDto employeeCreateDto);
        bool UpdateEmployee(EmployeeCreateDto employeeCreateDto, Guid id);
        void DeleteEmployee(Guid employeeId);
    }
}
