
using BookStoreApi.Modules.Books.Dtos.Responses;
using BookStoreApi.Modules.Books.Repostories.Interfaces;
using BookStoreApi.Modules.Books.Services.Interfaces;

using FluentResults;

namespace BookStoreApi.Modules.Books.Services.Implementations;

public class BookService(IBookRepository bookRepository) : IBookService
{
    public Task<Result<BookResponseTo>> GetBookByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Result<List<BookResponseTo>>> GetBooksByPublishDateAsync(DateTime publishDate)
    {
        throw new NotImplementedException();
    }

    public Task<Result<List<BookResponseTo>>> GetBooksByTitleAsync(string title)
    {
        throw new NotImplementedException();
    }
}
