using PSP_PoS.Components.CustomerComponent;
using PSP_PoS.Components.OrderItemsComponent;
using PSP_PoS.Components.OrderServicesComponent;
using PSP_PoS.Enums;

namespace PSP_PoS.Components.OrderComponent
{
    public class OrderReadDto
    {
        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string OrderStatus { get; set; }

        public decimal? Tip { get; set; }

        public PaymentType? PaymentType { get; set; }

        public Guid CustomerId { get; set; }

        public Guid EmployeeId { get; set; }

        public Guid? TaxId { get; set; }
        
        public List<OrderItemIdDto>? Items { get; set; }

        public List<OrderServiceIdDto>? Services { get; set; }

        public OrderReadDto(Order order, List<OrderItemIdDto> orderItemIdDto, List<OrderServiceIdDto> orderServiceIdDto)
        {
            Id = order.Id;
            DateCreated = order.DateCreated;
            OrderStatus = ConvertOrderStatus(order.OrderStatus);
            Tip = order.Tip;
            PaymentType = order.PaymentType;
            CustomerId = order.CustomerId;
            EmployeeId = order.EmployeeId;
            TaxId = order.TaxId;
            Items = orderItemIdDto;
            Services = orderServiceIdDto;

        }

        private static string ConvertOrderStatus(Status orderStatus)
        {
            switch (orderStatus)
            {
                case Status.Initial:
                    return "Initial";
                case Status.InProgress:
                    return "InProgress";
                case Status.Cancelled:
                    return "Cancelled";
                case Status.Reserved:
                    return "Reserved";
                case Status.Failed:
                    return "Failed";
                case Status.Finished:
                    return "Finished";
                default:
                    return "Unknown";
            }
        }
    }
}
