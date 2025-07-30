using AutoMapper;

using BookStoreApi.Modules.Books;
using BookStoreApi.Modules.Books.Dtos.Requests;
using BookStoreApi.Modules.Books.Dtos.Responses;

namespace BookStoreApi.Model.MappingProfiles;

public class BookMappingProfile : Profile
{
    public BookMappingProfile()
    {
        _ = CreateMap<BookRequestTo, Book>();
        _ = CreateMap<Book, BookResponseTo>()
            .ConstructUsing(src => new BookResponseTo());
    }
}
