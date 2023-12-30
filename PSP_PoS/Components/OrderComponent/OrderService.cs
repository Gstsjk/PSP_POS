using PSP_PoS.Data;

namespace PSP_PoS.Components.OrderComponent
{
    public class OrderService: IOrderService
    {
        private readonly DataContext _context;

        public OrderService(DataContext context)
        {
            _context = context;
        }  
        
        public Order AddOrder(OrderCreateDto orderCreateDto)
        {
            Order order = new Order(orderCreateDto);
        }
    }
}
