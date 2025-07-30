using BookStoreApi.Modules.Orders.Dtos.Requests;
using BookStoreApi.Modules.Orders.Dtos.Responses;

using FluentResults;

namespace BookStoreApi.Modules.Orders.Services.Interfaces;

public interface IOrderService
{
    Task<Result<List<OrderResponseTo>>> GetOrdersByDateAsync(DateTime date);
    Task<Result<OrderResponseTo>> GetOrderByIdAsync(int id);
    Task<Result<OrderResponseTo>> CreateOrderAsync(OrderRequestTo orderRequest);
}
