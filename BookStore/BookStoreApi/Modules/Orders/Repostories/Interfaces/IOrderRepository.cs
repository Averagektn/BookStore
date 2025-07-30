using BookStoreApi.Modules.Orders.Dtos.Requests;
using BookStoreApi.Modules.Orders.Dtos.Responses;

using FluentResults;

namespace BookStoreApi.Modules.Orders.Repostories.Interfaces;

public interface IOrderRepository
{
    Task<List<Order>> GetOrdersByDateAsync(DateTime date);
    Task<Order> GetOrderByIdAsync(int id);
    Task<Order> CreateOrderAsync(Order order);
}
