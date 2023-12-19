namespace PSP_PoS.Components.Reservation
{
    public class ReservationModel
    {
        public Guid Id { get; set; }
        public Guid ServiceId { get; set; }
        public Guid TableId { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime? Date { get; set; }
        public int Status { get; set; }
    }
}
