using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Modules.Orders;

[ApiController]
[Route("/api/v1/orders")]
public class OrderController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return Json("test");
    }
}
