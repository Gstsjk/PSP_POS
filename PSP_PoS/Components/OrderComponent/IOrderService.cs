using PSP_PoS.Components.ItemOrderComponent;
using PSP_PoS.Components.OrderService;
using PSP_PoS.OtherDtos;

namespace PSP_PoS.Components.OrderComponent
{
    public interface IOrderService
    {
        List<OrderReadDto> GetAllOrders();
        OrderReadDto GetOrderById(Guid orderId);
        Order AddOrder(OrderCreateDto order);
        OrderItems AddItemToOrder(Guid orderId, Guid itemId);
        OrderServices AddServiceToOrder(Guid orderId, Guid serviceId);
        Cheque GenerateCheque(Guid orderId);

        bool RemoveItemFromOrder(Guid orderId, Guid itemId);
        bool RemoveServiceFromOrder(Guid orderId, Guid itemId);
        bool IfCustomerIdValid(Guid id);
        bool IfEmployeeIdValid(Guid id);
        bool IfOrderIdValid(Guid id);
        bool IfItemIdValid(Guid id);
        bool IfServiceIdValid(Guid id);
        public bool IfItemExists(Guid itemId);
    }
}
