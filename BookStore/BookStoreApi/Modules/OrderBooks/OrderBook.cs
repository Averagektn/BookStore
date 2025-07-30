using BookStoreApi.Modules.Books;
using BookStoreApi.Modules.Orders;

namespace BookStoreApi.Modules.OrderBooks;

public class OrderBook
{
    public int OrderId { get; set; }
    public Order Order { get; set; } = null!;

    public int BookId { get; set; }
    public Book Book { get; set; } = null!;

    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
