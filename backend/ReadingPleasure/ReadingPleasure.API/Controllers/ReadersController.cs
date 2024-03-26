using Microsoft.AspNetCore.Mvc;
using ReadingPleasure.Abstractions.Application.Services;
using ReadingPleasure.Common.Constants;
using ReadingPleasure.Common.DTOs.Reader;

namespace ReadingPleasure.API.Controllers
{
    [ApiController]
    [Route(Constants.ApiEndpoints.Readers.Base)]
    public class ReadersController: ControllerBase
    {
        private readonly IReaderService _readerService;

        public ReadersController(IReaderService readerService)
        {
            _readerService = readerService;
        }

        [HttpGet(Constants.ApiEndpoints.Readers.GetAll)]
        public async Task<IActionResult> GetAll(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        CancellationToken cancellationToken = default)
        {
            var readers = await _readerService.GetReadersAsync(pageNumber, pageSize, cancellationToken);
            return Ok(readers);
        }

        [HttpGet(Constants.ApiEndpoints.Readers.GetById)]
        public async Task<IActionResult> GetById(
            [FromRoute] Guid id,
            CancellationToken cancellationToken)
        {
            var reader = await _readerService.GetReaderByIdAsync(id, cancellationToken);
            return Ok(reader);
        }

        [HttpPost(Constants.ApiEndpoints.Readers.Create)]
        public async Task<IActionResult> Create(
            [FromBody] CreateReaderDto createReaderDto,
            CancellationToken cancellationToken)
        {
            var reader = await _readerService
                .CreateReaderAsync(createReaderDto, cancellationToken);
            return Ok(reader);
        }

        [HttpPut(Constants.ApiEndpoints.Readers.Update)]
        public async Task<IActionResult> Update(
        [FromRoute] Guid id,
            [FromBody] UpdateReaderDto updateReaderDto,
            CancellationToken cancellationToken)
        {
            await _readerService.UpdateReaderAsync(id, updateReaderDto, cancellationToken);
            return NoContent();
        }

        [HttpDelete(Constants.ApiEndpoints.Readers.Delete)]
        public async Task<IActionResult> Delete(
            [FromRoute] Guid id,
            CancellationToken cancellationToken)
        {
            await _readerService.DeleteReaderAsync(id, cancellationToken);
            return NoContent();
        }
    }
}
