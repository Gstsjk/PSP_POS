using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PSP_PoS.Components.Reservation
{
    public class ReservationModel
    {
        [Key]
        [Required]
        [ForeignKey("OrderModel")]
        public Guid OrderId { get; set; }

        [Key]
        [Required]
        [ForeignKey("ServiceModel")]
        public Guid ServiceId { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}
