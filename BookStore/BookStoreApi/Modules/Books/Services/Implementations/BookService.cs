using AutoMapper;

using BookStoreApi.Modules.Books.Dtos.Responses;
using BookStoreApi.Modules.Books.Repostories.Interfaces;
using BookStoreApi.Modules.Books.Services.Interfaces;

using FluentResults;

namespace BookStoreApi.Modules.Books.Services.Implementations;

public class BookService(IBookRepository bookRepository, IMapper mapper) : IBookService
{
    public async Task<Result<BookResponseTo>> GetBookByIdAsync(int id)
    {
        Result<Book> bookResult = await Result.Try(async Task<Book> () => await bookRepository.GetBookByIdAsync(id));

        return Result.FailIf(bookResult.IsFailed, new Error($"Book not found by id {id}"))
            .Bind<BookResponseTo>(() => mapper.Map<BookResponseTo>(bookResult.Value));
    }

    public async Task<Result<List<BookResponseTo>>> GetBooksByPublishDateAsync(DateOnly publishDate)
    {
        Result<List<Book>> bookResult = await Result.Try(async Task<List<Book>> () => await bookRepository.GetBooksByPublishDateAsync(publishDate));

        return Result.FailIf(bookResult.IsFailed, new Error($"Book not found by publish date {publishDate}"))
            .Bind<List<BookResponseTo>>(() => mapper.Map<List<BookResponseTo>>(bookResult.Value));
    }

    public async Task<Result<List<BookResponseTo>>> GetBooksByTitleAsync(string title)
    {
        Result<List<Book>> booksResult = await Result.Try(async Task<List<Book>> () => await bookRepository.GetBooksByTitleAsync(title));

        return Result.FailIf(booksResult.IsFailed, new Error($"Books not found by title {title}"))
            .Bind<List<BookResponseTo>>(() => mapper.Map<List<BookResponseTo>>(booksResult.Value));
    }
}
