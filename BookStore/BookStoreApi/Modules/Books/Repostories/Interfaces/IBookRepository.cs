using BookStoreApi.Modules.Books.Dtos.Responses;

using FluentResults;

namespace BookStoreApi.Modules.Books.Repostories.Interfaces;

public interface IBookRepository
{
    Task<List<Book>> GetBooksByTitleAsync(string title);
    Task<List<Book>> GetBooksByPublishDateAsync(DateOnly publishDate);
    Task<Book> GetBookByIdAsync(int id);
}
