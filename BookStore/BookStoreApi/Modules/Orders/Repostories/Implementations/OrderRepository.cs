using BookStoreApi.Model.Db;
using BookStoreApi.Modules.Orders.Repostories.Interfaces;

namespace BookStoreApi.Modules.Orders.Repostories.Implementations;

public class OrderRepository(BookStoreContext context) : IOrderRepository
{
}
