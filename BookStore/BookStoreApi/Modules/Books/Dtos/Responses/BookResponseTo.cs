namespace BookStoreApi.Modules.Books.Dtos.Responses;

public record BookResponseTo(int Id, string Title, string? Description, string Author, decimal Price, DateOnly PublishDate, int StockQuantity);
