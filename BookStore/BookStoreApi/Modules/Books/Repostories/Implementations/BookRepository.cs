using BookStoreApi.Model.Db;
using BookStoreApi.Modules.Books.Repostories.Interfaces;

namespace BookStoreApi.Modules.Books.Repostories.Implementations;

public class BookRepository(BookStoreContext context) : IBookRepository
{
}
