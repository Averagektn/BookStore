using BookStoreApi.Model.Db;
using BookStoreApi.Modules.Orders.Exceptions;
using BookStoreApi.Modules.Orders.Repostories.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Modules.Orders.Repostories.Implementations;

public class OrderRepository(BookStoreContext context) : IOrderRepository
{
    public async Task<Order> CreateOrderAsync(Order order)
    {
        _ = await context.Orders.AddAsync(order);
        _ = await context.SaveChangesAsync();

        return order;
    }

    public async Task<Order> GetOrderByIdAsync(int id)
    {
        Order? order = await context.Orders.FindAsync(id);

        return order ?? throw new OrderNotFoundException();
    }

    public async Task<List<Order>> GetOrdersByDateAsync(DateTime date)
    {
        List<Order> orders = await context.Orders.Where(order => order.CreatedAt.Date == date.Date).ToListAsync();

        return orders;
    }
}
