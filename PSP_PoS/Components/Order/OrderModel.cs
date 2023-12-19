namespace PSP_PoS.Components.Order
{
    public class OrderModel
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime? Date { get; set; }
        public int OrderStatus { get; set; }
        public int OrderType { get; set; }
        public int TotalPrice { get; set; } // in cents
    }
}
