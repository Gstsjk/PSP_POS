namespace PSP_PoS.Components.OrderComponent
{
    public interface IOrderService
    {
        List<OrderCreateDto> GetAllOrders();
        OrderReadDto GetOrderById(Guid orderId);
        Order AddOrder(OrderCreateDto order);
    }
}
