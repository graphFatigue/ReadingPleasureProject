using Microsoft.AspNetCore.Mvc;
using ReadingPleasure.Abstractions.Application.Services;
using ReadingPleasure.Common.Constants;
using ReadingPleasure.Common.DTOs.Book;

namespace ReadingPleasure.API.Controllers
{
    [ApiController]
    [Route(Constants.ApiEndpoints.Books.Base)]
    public class BooksController: ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet(Constants.ApiEndpoints.Books.GetAll)]
        public async Task<IActionResult> GetAll(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            CancellationToken cancellationToken = default)
        {
            var books = await _bookService.GetBooksAsync(pageNumber, pageSize, cancellationToken);
            return Ok(books);
        }

        [HttpGet(Constants.ApiEndpoints.Books.GetByAuthorId)]
        public async Task<IActionResult> GetByAuthorId(
            [FromRoute] Guid authorId,
            CancellationToken cancellationToken)
        {
            var books = await _bookService.GetBooksByAuthorId(authorId, cancellationToken);
            return Ok(books);
        }

        [HttpGet(Constants.ApiEndpoints.Books.GetById)]
        public async Task<IActionResult> GetById(
            [FromRoute] Guid id,
            CancellationToken cancellationToken)
        {
            var book = await _bookService.GetBookByIdAsync(id, cancellationToken);
            return Ok(book);
        }

        [HttpPost(Constants.ApiEndpoints.Books.Create)]
        public async Task<IActionResult> Create(
            [FromBody] CreateBookDto createBookDto,
            CancellationToken cancellationToken)
        {
            await _bookService
                 .CreateBookAsync(createBookDto, cancellationToken);
            return NoContent();
        }

        [HttpPut(Constants.ApiEndpoints.Books.Update)]
        public async Task<IActionResult> Update(
        [FromRoute] Guid id,
            [FromBody] UpdateBookDto updateBookDto,
            CancellationToken cancellationToken)
        {
            await _bookService.UpdateBookAsync(id, updateBookDto, cancellationToken);
            return NoContent();
        }

        [HttpDelete(Constants.ApiEndpoints.Books.Delete)]
        public async Task<IActionResult> Delete(
            [FromRoute] Guid id,
            CancellationToken cancellationToken)
        {
            await _bookService.DeleteBookAsync(id, cancellationToken);
            return NoContent();
        }
    }
}
