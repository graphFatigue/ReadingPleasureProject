using Microsoft.AspNetCore.Mvc;
using ReadingPleasure.Abstractions.Application.Services;
using ReadingPleasure.Common.Constants;
using ReadingPleasure.Common.DTOs.Genre;

namespace ReadingPleasure.API.Controllers
{
    [ApiController]
    [Route(Constants.ApiEndpoints.Genres.Base)]
    public class GenresController: ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet(Constants.ApiEndpoints.Genres.GetAll)]
        public async Task<IActionResult> GetAll(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        CancellationToken cancellationToken = default)
        {
            var genres = await _genreService.GetGenresAsync(pageNumber, pageSize, cancellationToken);
            return Ok(genres);
        }

        [HttpGet(Constants.ApiEndpoints.Genres.GetById)]
        public async Task<IActionResult> GetById(
            [FromRoute] Guid id,
            CancellationToken cancellationToken)
        {
            var genre = await _genreService.GetGenreByIdAsync(id, cancellationToken);
            return Ok(genre);
        }

        [HttpPost(Constants.ApiEndpoints.Genres.Create)]
        public async Task<IActionResult> Create(
            [FromBody] CreateGenreDto createGenreDto,
            CancellationToken cancellationToken)
        {
            var genre = await _genreService
                .CreateGenreAsync(createGenreDto, cancellationToken);
            return Ok(genre);
        }

        [HttpPut(Constants.ApiEndpoints.Genres.Update)]
        public async Task<IActionResult> Update(
        [FromRoute] Guid id,
            [FromBody] UpdateGenreDto updateGenreDto,
            CancellationToken cancellationToken)
        {
            await _genreService.UpdateGenreAsync(id, updateGenreDto, cancellationToken);
            return NoContent();
        }

        [HttpDelete(Constants.ApiEndpoints.Genres.Delete)]
        public async Task<IActionResult> Delete(
            [FromRoute] Guid id,
            CancellationToken cancellationToken)
        {
            await _genreService.DeleteGenreAsync(id, cancellationToken);
            return NoContent();
        }
    }
}

