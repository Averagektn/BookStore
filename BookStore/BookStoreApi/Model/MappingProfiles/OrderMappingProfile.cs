using AutoMapper;

using BookStoreApi.Modules.Orders;
using BookStoreApi.Modules.Orders.Dtos.Responses;

namespace BookStoreApi.Model.MappingProfiles;

public class OrderMappingProfile : Profile
{
    public OrderMappingProfile()
    {
        _ = CreateMap<Order, OrderResponseTo>()
            .ConstructUsing(src => new OrderResponseTo(src.Id, src.CreatedAt, src.TotalPrice));
    }
}
