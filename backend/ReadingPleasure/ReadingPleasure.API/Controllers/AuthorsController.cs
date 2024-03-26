using Microsoft.AspNetCore.Mvc;
using ReadingPleasure.Abstractions.Application.Services;
using ReadingPleasure.Common.Constants;
using ReadingPleasure.Common.DTOs.Author;

namespace ReadingPleasure.API.Controllers
{
    [ApiController]
    [Route(Constants.ApiEndpoints.Authors.Base)]
    public class AuthorsController: ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet(Constants.ApiEndpoints.Authors.GetAll)]
        public async Task<IActionResult> GetAll(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        CancellationToken cancellationToken = default)
        {
            var authors = await _authorService.GetAuthorsAsync(pageNumber, pageSize, cancellationToken);
            return Ok(authors);
        }

        [HttpGet(Constants.ApiEndpoints.Authors.GetById)]
        public async Task<IActionResult> GetById(
            [FromRoute] Guid id,
            CancellationToken cancellationToken)
        {
            var author = await _authorService.GetAuthorByIdAsync(id, cancellationToken);
            return Ok(author);
        }

        [HttpPost(Constants.ApiEndpoints.Authors.Create)]
        public async Task<IActionResult> Create(
            [FromBody] CreateAuthorDto createAuthorDto,
            CancellationToken cancellationToken)
        {
            var author = await _authorService
                .CreateAuthorAsync(createAuthorDto, cancellationToken);
            return Ok(author);
        }

        [HttpPut(Constants.ApiEndpoints.Authors.Update)]
        public async Task<IActionResult> Update(
            [FromRoute] Guid id,
            [FromBody] UpdateAuthorDto updateAuthorDto,
            CancellationToken cancellationToken)
        {
            await _authorService.UpdateAuthorAsync(id, updateAuthorDto, cancellationToken);
            return NoContent();
        }

        [HttpDelete(Constants.ApiEndpoints.Authors.Delete)]
        public async Task<IActionResult> Delete(
            [FromRoute] Guid id,
            CancellationToken cancellationToken)
        {
            await _authorService.DeleteAuthorAsync(id, cancellationToken);
            return NoContent();
        }
    }
}
