using BookStoreApi.Modules.Books.Dtos.Responses;
using BookStoreApi.Modules.Books.Services.Interfaces;

using FluentResults;

using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Modules.Books;

[ApiController]
[Route("/api/v1/books")]
public class BookController(IBookService bookService) : Controller
{
    [HttpGet]
    [Route("filter/title")]
    public async Task<IActionResult> GetBooksByTitleAsync([FromQuery] string title)
    {
        Result<List<BookResponseTo>> result = await bookService.GetBooksByTitleAsync(title);

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
    [Route("filter/date")]
    public async Task<IActionResult> GetBooksByPublishDateAsync([FromQuery] DateTime date)
    {
        Result<List<BookResponseTo>> result = await bookService.GetBooksByPublishDateAsync(date);

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
    public async Task<IActionResult> GetBookByIdAsync([FromRoute] int id)
    {
        Result<BookResponseTo> result = await bookService.GetBookByIdAsync(id);

        if (result.IsSuccess)
        {
            return new JsonResult(result.Value)
            {
                StatusCode = StatusCodes.Status200OK
            };
        }

        return NotFound();
    }
}
