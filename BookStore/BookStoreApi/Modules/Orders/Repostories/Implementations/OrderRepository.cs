using BookStoreApi.Model.Db;
using BookStoreApi.Modules.Books;
using BookStoreApi.Modules.OrderBooks;
using BookStoreApi.Modules.Orders.Exceptions;
using BookStoreApi.Modules.Orders.Repostories.Interfaces;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace BookStoreApi.Modules.Orders.Repostories.Implementations;

public class OrderRepository(BookStoreContext context) : IOrderRepository
{
    public async Task<Order> CreateOrderAsync(List<OrderBook> orderBooks)
    {
        using IDbContextTransaction transaction = await context.Database.BeginTransactionAsync();

        try
        {
            var bookIds = orderBooks.Select(ob => ob.BookId).ToList();

            List<Book> books = await context.Books
                .Where(b => bookIds.Contains(b.Id))
                .ToListAsync();

            foreach (OrderBook ob in orderBooks)
            {
                Book? book = books.FirstOrDefault(b => b.Id == ob.BookId) ??
                    throw new Exception($"Book with ID {ob.BookId} not found.");

                if (book.StockQuantity < ob.Quantity)
                {
                    throw new Exception($"Not enough stock for book {book.Title}. Available: {book.StockQuantity}, " +
                        $"requested: {ob.Quantity}");
                }

                book.StockQuantity -= ob.Quantity;

                ob.Price = book.Price;
            }

            decimal totalPrice = orderBooks.Sum(ob => ob.Price * ob.Quantity);

            var order = new Order
            {
                CreatedAt = DateTime.UtcNow,
                TotalPrice = totalPrice,
            };

            _ = await context.Orders.AddAsync(order);
            _ = await context.SaveChangesAsync();

            foreach (OrderBook ob in orderBooks)
            {
                ob.OrderId = order.Id;
            }

            await context.OrderBooks.AddRangeAsync(orderBooks);
            _ = await context.SaveChangesAsync();

            await transaction.CommitAsync();

            return order;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<Order> GetOrderByIdAsync(int id)
    {
        Order? order = await context.Orders.FindAsync(id);

        return order ?? throw new OrderNotFoundException();
    }

    public async Task<List<Order>> GetOrdersByDateAsync(DateOnly date)
    {
        List<Order> orders = await context.Orders.Where(order => DateOnly.FromDateTime(order.CreatedAt) == date).ToListAsync();

        return orders;
    }
}
