using Microsoft.AspNetCore.Mvc;
using ReadingPleasure.Abstractions.Application.Services;
using ReadingPleasure.Common.Constants;
using ReadingPleasure.Common.DTOs.Edition;

namespace ReadingPleasure.API.Controllers
{
    [ApiController]
    [Route(Constants.ApiEndpoints.Editions.Base)]
    public class EditionsController: ControllerBase
    {
        private readonly IEditionService _editionService;

        public EditionsController(IEditionService editionService)
        {
            _editionService = editionService;
        }

        [HttpGet(Constants.ApiEndpoints.Editions.GetAll)]
        public async Task<IActionResult> GetAll(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        CancellationToken cancellationToken = default)
        {
            var editions = await _editionService.GetEditionsAsync(pageNumber, pageSize, cancellationToken);
            return Ok(editions);
        }

        [HttpGet(Constants.ApiEndpoints.Editions.GetById)]
        public async Task<IActionResult> GetById(
            [FromRoute] Guid id,
            CancellationToken cancellationToken)
        {
            var edition = await _editionService.GetEditionByIdAsync(id, cancellationToken);
            return Ok(edition);
        }

        [HttpPost(Constants.ApiEndpoints.Editions.Create)]
        public async Task<IActionResult> Create(
            [FromBody] CreateEditionDto createEditionDto,
            CancellationToken cancellationToken)
        {
            var edition = await _editionService
                .CreateEditionAsync(createEditionDto, cancellationToken);
            return Ok(edition);
        }

        [HttpPut(Constants.ApiEndpoints.Editions.Update)]
        public async Task<IActionResult> Update(
            [FromRoute] Guid id,
            [FromBody] UpdateEditionDto updateEditionDto,
            CancellationToken cancellationToken)
        {
            await _editionService.UpdateEditionAsync(id, updateEditionDto, cancellationToken);
            return NoContent();
        }

        [HttpDelete(Constants.ApiEndpoints.Editions.Delete)]
        public async Task<IActionResult> Delete(
            [FromRoute] Guid id,
            CancellationToken cancellationToken)
        {
            await _editionService.DeleteEditionAsync(id, cancellationToken);
            return NoContent();
        }
    }
}
