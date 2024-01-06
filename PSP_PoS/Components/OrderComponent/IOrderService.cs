using PSP_PoS.Components.ItemOrderComponent;
using PSP_PoS.Components.OrderService;
using PSP_PoS.Enums;
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
        bool AddTaxToOrder(Guid orderId, Guid taxId);
        bool RemoveTaxFromOrder(Guid orderId);
        Cheque GenerateCheque(Guid orderId);
        void DeleteOrder(Guid orderId);
        bool RemoveItemFromOrder(Guid orderId, Guid itemId);
        bool RemoveServiceFromOrder(Guid orderId, Guid itemId);
        bool PayForOrder(Guid orderId, PaymentType payment);
        bool AddTip(Guid orderId, decimal amount);
        bool CloseOrder(Guid orderId);
        bool IfCustomerIdValid(Guid id);
        bool IfEmployeeIdValid(Guid id);
        bool IfOrderIdValid(Guid id);
        bool IfItemIdValid(Guid id);
        bool IfServiceIdValid(Guid id);
        public bool IfItemExists(Guid itemId);
    }
}
