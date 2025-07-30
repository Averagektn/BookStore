
using BookStoreApi.Modules.Orders.Dtos.Requests;
using BookStoreApi.Modules.Orders.Dtos.Responses;
using BookStoreApi.Modules.Orders.Repostories.Interfaces;
using BookStoreApi.Modules.Orders.Services.Interfaces;

using FluentResults;

namespace BookStoreApi.Modules.Orders.Services.Implementations;

public class OrderService(IOrderRepository orderRepository) : IOrderService
{
    public Task<Result<OrderResponseTo>> CreateOrderAsync(OrderRequestTo orderRequest)
    {
        throw new NotImplementedException();
    }

    public Task<Result<OrderResponseTo>> GetOrderByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Result<List<OrderResponseTo>>> GetOrdersByDateAsync(DateTime date)
    {
        throw new NotImplementedException();
    }
}
