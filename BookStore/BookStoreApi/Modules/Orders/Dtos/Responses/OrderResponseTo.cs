namespace BookStoreApi.Modules.Orders.Dtos.Responses;

public record OrderResponseTo(int Id, DateTime CreatedAt, decimal TotalPrice);
