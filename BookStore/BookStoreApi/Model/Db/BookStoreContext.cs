using BookStoreApi.Model.Db.Configurations;
using BookStoreApi.Modules.Books;
using BookStoreApi.Modules.Orders;

using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Model.Db;

public class BookStoreContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Order> Orders { get; set; }

    public BookStoreContext() : base() { }

    public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        _ = modelBuilder
            .ApplyConfiguration(new BookConfiguration())
            .ApplyConfiguration(new OrderBookConfiguration())
            .ApplyConfiguration(new OrderConfiguration());
    }
}
