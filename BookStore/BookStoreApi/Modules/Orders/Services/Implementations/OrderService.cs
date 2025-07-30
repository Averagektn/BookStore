using AutoMapper;

using BookStoreApi.Modules.OrderBooks;
using BookStoreApi.Modules.OrderBooks.Dtos.Requests;
using BookStoreApi.Modules.Orders.Dtos.Responses;
using BookStoreApi.Modules.Orders.Repostories.Interfaces;
using BookStoreApi.Modules.Orders.Services.Interfaces;

using FluentResults;

namespace BookStoreApi.Modules.Orders.Services.Implementations;

public class OrderService(IOrderRepository orderRepository, IMapper mapper) : IOrderService
{
    public async Task<Result<OrderResponseTo>> CreateOrderAsync(List<OrderBookRequestTo> orderItemsRequest)
    {
        List<OrderBook> orderBooks = mapper.Map<List<OrderBook>>(orderItemsRequest);
        Result<Order> createOrderResult = await Result.Try(async Task<Order> () => await orderRepository.CreateOrderAsync(orderBooks));

        return Result.FailIf(createOrderResult.IsFailed, new Error("Failed to create order"))
            .Bind<OrderResponseTo>(() => mapper.Map<OrderResponseTo>(createOrderResult.Value));
    }

    public async Task<Result<OrderResponseTo>> GetOrderByIdAsync(int id)
    {
        Result<Order> getOrderById = await Result.Try(async Task<Order> () => await orderRepository.GetOrderByIdAsync(id));

        return Result.FailIf(getOrderById.IsFailed, new Error($"Order not found by ID {id}"))
            .Bind<OrderResponseTo>(() => mapper.Map<OrderResponseTo>(getOrderById.Value));
    }

    public async Task<Result<List<OrderResponseTo>>> GetOrdersByDateAsync(DateOnly date)
    {
        Result<List<Order>> getOrdersByDate = await Result
            .Try(async Task<List<Order>> () => await orderRepository.GetOrdersByDateAsync(date));

        return Result.FailIf(getOrdersByDate.IsFailed, new Error($"Order not found by date {date}"))
            .Bind<List<OrderResponseTo>>(() => mapper.Map<List<OrderResponseTo>>(getOrdersByDate.Value));
    }
}
