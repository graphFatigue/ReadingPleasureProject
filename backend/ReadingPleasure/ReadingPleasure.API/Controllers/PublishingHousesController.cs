using Microsoft.AspNetCore.Mvc;
using ReadingPleasure.Abstractions.Application.Services;
using ReadingPleasure.Common.Constants;
using ReadingPleasure.Common.DTOs.PublishingHouse;

namespace ReadingPleasure.API.Controllers
{
    [ApiController]
    [Route(Constants.ApiEndpoints.PublishingHouses.Base)]
    public class PublishingHousesController: ControllerBase
    {
        private readonly IPublishingHouseService _publishingHouseService;

        public PublishingHousesController(IPublishingHouseService publishingHouseService)
        {
            _publishingHouseService = publishingHouseService;
        }

        [HttpGet(Constants.ApiEndpoints.PublishingHouses.GetAll)]
        public async Task<IActionResult> GetAll(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        CancellationToken cancellationToken = default)
        {
            var publishingHouses = await _publishingHouseService.GetPublishingHousesAsync(pageNumber, pageSize, cancellationToken);
            return Ok(publishingHouses);
        }

        [HttpGet(Constants.ApiEndpoints.PublishingHouses.GetById)]
        public async Task<IActionResult> GetById(
            [FromRoute] Guid id,
            CancellationToken cancellationToken)
        {
            var publishingHouses = await _publishingHouseService.GetPublishingHouseByIdAsync(id, cancellationToken);
            return Ok(publishingHouses);
        }

        [HttpPost(Constants.ApiEndpoints.PublishingHouses.Create)]
        public async Task<IActionResult> Create(
            [FromBody] CreatePublishingHouseDto createPublishingHouseDto,
            CancellationToken cancellationToken)
        {
            var publishingHouse = await _publishingHouseService
                .CreatePublishingHouseAsync(createPublishingHouseDto, cancellationToken);
            return Ok(publishingHouse);
        }

        [HttpPut(Constants.ApiEndpoints.PublishingHouses.Update)]
        public async Task<IActionResult> Update(
        [FromRoute] Guid id,
            [FromBody] UpdatePublishingHouseDto updatePublishingHouseDto,
            CancellationToken cancellationToken)
        {
            await _publishingHouseService.UpdatePublishingHouseAsync(id, updatePublishingHouseDto, cancellationToken);
            return NoContent();
        }

        [HttpDelete(Constants.ApiEndpoints.PublishingHouses.Delete)]
        public async Task<IActionResult> Delete(
            [FromRoute] Guid id,
            CancellationToken cancellationToken)
        {
            await _publishingHouseService.DeletePublishingHouseAsync(id, cancellationToken);
            return NoContent();
        }
    }
}
