using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Modules.Books;

[ApiController]
[Route("/api/v1/books")]
public class BookController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return Json("test");
    }
}
