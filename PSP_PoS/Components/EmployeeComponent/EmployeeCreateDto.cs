using PSP_PoS.Enums;
using PSP_PoS.OtherDtos;

namespace PSP_PoS.Components.EmployeeComponent
{
    public class EmployeeCreateDto
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int Privileges { get; set; }

        public WorkingDays WorkingDays { get; set; }

        public TimeDto StartTime { get; set; }

        public TimeDto EndTime { get; set; }
    }
}
