using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PSP_PoS.Components.ReservationComponent
{
    public class Reservation
    {
        [Key]
        [Required]
        [ForeignKey("Order")]
        public Guid OrderId { get; set; }

        [Key]
        [Required]
        [ForeignKey("Service")]
        public Guid ServiceId { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public Reservation() { }
    }
}
