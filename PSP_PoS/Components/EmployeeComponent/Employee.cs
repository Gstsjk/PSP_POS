using PSP_PoS.Components.OrderComponent;
using PSP_PoS.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using PSP_PoS.OtherDtos;

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

        //Navigation
        [JsonIgnore]
        public List<Order> Orders { get; set; }

        public Employee()
        {

        }

        public Employee(EmployeeCreateDto employeeCreateDto)
        {
            Username = employeeCreateDto.Username;
            Password = employeeCreateDto.Password;
            Name = employeeCreateDto.Name;
            Surname = employeeCreateDto.Surname;
            Privileges = employeeCreateDto.Privileges;
            StartTime = employeeCreateDto.StartTime.Hours * 60 + employeeCreateDto.StartTime.Minutes;
            EndTime = employeeCreateDto.EndTime.Hours * 60 + employeeCreateDto.StartTime.Minutes;
        }

        public void UpdateEmployee(EmployeeCreateDto employeeCreateDto)
        {
            Username = employeeCreateDto.Username;
            Password = employeeCreateDto.Password;
            Name = employeeCreateDto.Name;
            Surname = employeeCreateDto.Surname;
            Privileges = employeeCreateDto.Privileges;
            StartTime = employeeCreateDto.StartTime.Hours * 60 + employeeCreateDto.StartTime.Minutes;
            EndTime = employeeCreateDto.EndTime.Hours * 60 + employeeCreateDto.StartTime.Minutes;
        }
    }
}
