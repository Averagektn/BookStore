using AutoMapper;

using BookStoreApi.Modules.Orders;
using BookStoreApi.Modules.Orders.Dtos.Requests;
using BookStoreApi.Modules.Orders.Dtos.Responses;

namespace BookStoreApi.Model.MappingProfiles;

public class OrderMappingProfile : Profile
{
    public OrderMappingProfile()
    {
        _ = CreateMap<OrderRequestTo, Order>();
        _ = CreateMap<Order, OrderResponseTo>();
    }
}
