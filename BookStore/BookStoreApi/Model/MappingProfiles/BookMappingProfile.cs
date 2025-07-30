using AutoMapper;

using BookStoreApi.Modules.Books;
using BookStoreApi.Modules.Books.Dtos.Requests;
using BookStoreApi.Modules.Books.Dtos.Responses;

namespace BookStoreApi.Model.MappingProfiles;

public class BookMappingProfile : Profile
{
    public BookMappingProfile()
    {
        _ = CreateMap<BookRequestTo, Book>()
            .ConstructUsing(src => new Book()
            {
                Author = src.Author,
                Description = src.Description,
                Price = src.Price,
                PublishDate = src.PublishDate,
                StockQuantity = src.StockQuantity,
                Title = src.Title
            });

        _ = CreateMap<Book, BookResponseTo>()
            .ConstructUsing(src => new BookResponseTo(src.Id, src.Title, src.Description, src.Author, src.Price, src.PublishDate,
                src.StockQuantity));
    }
}
