using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSP_PoS.Components.Reservation
{
    public class ReservationModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [ForeignKey("ServiceModel")]
        public Guid ServiceId { get; set; }
        [ForeignKey("EmployeeModel")]
        public Guid EmployeeId { get; set; }
        [ForeignKey("CustomerModel")]
        public Guid CustomerId { get; set; }
        public DateTime? Date { get; set; }
        public int TableNumber { get; set; } // keiciam is guid i int, nes nera table lenteles kontrakt'e
        public int Status { get; set; }
    }
}
