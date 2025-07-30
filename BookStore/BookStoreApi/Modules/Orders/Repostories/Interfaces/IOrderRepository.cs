namespace BookStoreApi.Modules.Orders.Repostories.Interfaces;

public interface IOrderRepository
{
    Task<List<Order>> GetOrdersByDateAsync(DateOnly date);
    Task<Order> GetOrderByIdAsync(int id);
    Task<Order> CreateOrderAsync(Order order);
}
