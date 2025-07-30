using AutoMapper;

using BookStoreApi.Modules.OrderBooks;
using BookStoreApi.Modules.OrderBooks.Dtos.Requests;

namespace BookStoreApi.Model.MappingProfiles;

public class OrderBookMappingProfile : Profile
{
    public OrderBookMappingProfile()
    {
        _ = CreateMap<OrderBookRequestTo, OrderBook>()
            .ConstructUsing(src => new OrderBook()
            {
                BookId = src.BookId,
                Quantity = src.Quantity,
            });
    }
}
