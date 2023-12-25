using PSP_PoS.Enums;
using PSP_PoS.OtherDtos;

namespace PSP_PoS.Components.EmployeeComponent
{
    public class EmployeeWithIdDto
    {
        public Guid Id { get; set; }
        
        public string Username { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int Privileges { get; set; }

        public WorkingDays WorkingDays { get; set; }

        public TimeDto StartTime { get; set; }

        public TimeDto EndTime { get; set; }

        public EmployeeWithIdDto(Employee employee)
        {
            Id = employee.Id;
            Username = employee.Username;
            Password = employee.Password;
            Name = employee.Name;
            Surname = employee.Surname;
            Privileges = employee.Privileges;
            WorkingDays = employee.WorkingDays;

            StartTime = new TimeDto();
            StartTime.Hours = employee.StartTime / 60;
            StartTime.Minutes = employee.StartTime % 60;

            EndTime = new TimeDto();
            EndTime.Hours = employee.EndTime / 60;
            EndTime.Minutes = employee.EndTime % 60;
        }
    }
}
