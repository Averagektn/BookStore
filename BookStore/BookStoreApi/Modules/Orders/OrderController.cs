using BookStoreApi.Modules.OrderBooks.Dtos.Requests;
using BookStoreApi.Modules.Orders.Dtos.Responses;
using BookStoreApi.Modules.Orders.Services.Interfaces;

using FluentResults;

using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Modules.Orders;

[ApiController]
[Route("/api/v1/orders")]
public class OrderController(IOrderService orderService) : Controller
{
    [HttpGet]
    [Route("filter/date")]
    public async Task<IActionResult> GetOrdersByDateAsync([FromQuery] DateOnly date)
    {
        Result<List<OrderResponseTo>> result = await orderService.GetOrdersByDateAsync(date);

        if (result.IsSuccess)
        {
            return new JsonResult(result.Value)
            {
                StatusCode = StatusCodes.Status200OK
            };
        }

        return NotFound();
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetOrderByIdAsync([FromRoute] int id)
    {
        Result<OrderResponseTo> result = await orderService.GetOrderByIdAsync(id);

        if (result.IsSuccess)
        {
            return new JsonResult(result.Value)
            {
                StatusCode = StatusCodes.Status200OK
            };
        }

        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrderAsync([FromBody] List<OrderBookRequestTo> ordersRequest)
    {
        Result<OrderResponseTo> result = await orderService.CreateOrderAsync(ordersRequest);

        if (result.IsSuccess)
        {
            return new JsonResult(result.Value)
            {
                StatusCode = StatusCodes.Status201Created
            };
        }

        return NotFound();
    }
}
