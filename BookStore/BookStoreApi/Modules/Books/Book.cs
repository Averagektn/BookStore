using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using BookStoreApi.Modules.OrderBooks;

namespace BookStoreApi.Modules.Books;

public class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; } = null!;

    public string Author { get; set; } = null!;

    public decimal Price { get; set; }

    public DateTime PublishDate { get; set; }

    public int StockQuantity { get; set; }

    public ICollection<OrderBook> OrderBooks { get; set; } = null!;
}
