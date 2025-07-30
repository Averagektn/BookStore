using BookStoreApi.Model.Db;
using BookStoreApi.Modules.Books.Exceptions;
using BookStoreApi.Modules.Books.Repostories.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Modules.Books.Repostories.Implementations;

public class BookRepository(BookStoreContext context) : IBookRepository
{
    public async Task<Book> GetBookByIdAsync(int id)
    {
        Book? book = await context.Books.FindAsync(id);

        return book ?? throw new BookNotFoundException();
    }

    public async Task<List<Book>> GetBooksByPublishDateAsync(DateOnly publishDate)
    {
        List<Book> books = await context.Books.Where(book => book.PublishDate == publishDate).ToListAsync();

        return books;
    }

    public async Task<List<Book>> GetBooksByTitleAsync(string title)
    {
        List<Book> books = await context.Books.Where(book => book.Title == title).ToListAsync();

        return books;
    }
}
