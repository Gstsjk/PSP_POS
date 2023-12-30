using PSP_PoS.Components.CustomerComponent;
using PSP_PoS.Components.EmployeeComponent;
using PSP_PoS.Components.TaxComponent;
using PSP_PoS.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PSP_PoS.Components.OrderComponent
{
    public class OrderCreateDto
    {
        public Guid CustomerId { get; set; }

        public Guid EmployeeId { get; set; }
     
    }
}
