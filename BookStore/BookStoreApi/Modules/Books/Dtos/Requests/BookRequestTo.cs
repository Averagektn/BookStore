namespace BookStoreApi.Modules.Books.Dtos.Requests;

public record BookRequestTo(string Title, string? Description, string Author, decimal Price, DateOnly PublishDate, int StockQuantity);
