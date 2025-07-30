using BookStoreApi.Modules.Books;
using BookStoreApi.Modules.OrderBooks;

namespace BookStoreApi.Modules.Orders;

public class Order
{
    public int Id { get; set; }
    public ICollection<OrderBook> OrderBooks { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public decimal TotalPrice { get; set; }
}
