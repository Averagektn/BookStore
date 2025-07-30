using BookStoreApi.Modules.Books.Dtos.Responses;

using FluentResults;

namespace BookStoreApi.Modules.Books.Services.Interfaces;

public interface IBookService
{
    Task<Result<List<BookResponseTo>>> GetBooksByTitleAsync(string title);
    Task<Result<List<BookResponseTo>>> GetBooksByPublishDateAsync(DateTime publishDate);
    Task<Result<BookResponseTo>> GetBookByIdAsync(int id);
}
