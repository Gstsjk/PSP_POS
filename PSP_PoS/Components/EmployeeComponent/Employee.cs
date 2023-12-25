using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PSP_PoS.Enums;

namespace PSP_PoS.Components.EmployeeComponent
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public int Privileges { get; set; }

        [Required]
        public WorkingDays WorkingDays { get; set; }

        public int StartTime { get; set; }

        public int EndTime { get; set; }

        public Employee()
        {

        }

        public Employee(EmployeeDto employee)
        {
            Username = employee.Username;
            Password = employee.Password;
            Name = employee.Name;
            Surname = employee.Surname;
            Privileges = employee.Privileges;
            WorkingDays = employee.WorkingDays;
            StartTime = employee.StartTime.Hours*60+employee.StartTime.Minutes;
            EndTime = employee.EndTime.Hours*60+employee.StartTime.Minutes;
        }

        public void UpdateEmployee(EmployeeDto employee)
        {
            Username = employee.Username;
            Password = employee.Password;
            Name = employee.Name;
            Surname = employee.Surname;
            Privileges = employee.Privileges;
            WorkingDays = employee.WorkingDays;
            StartTime = employee.StartTime.Hours * 60 + employee.StartTime.Minutes;
            EndTime = employee.EndTime.Hours * 60 + employee.StartTime.Minutes;
        }

    }


}
