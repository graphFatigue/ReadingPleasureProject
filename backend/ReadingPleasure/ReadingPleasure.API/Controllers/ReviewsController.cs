using Microsoft.AspNetCore.Mvc;
using ReadingPleasure.Abstractions.Application.Services;
using ReadingPleasure.Application.Services;
using ReadingPleasure.Common.Constants;
using ReadingPleasure.Common.DTOs.Book;
using ReadingPleasure.Common.DTOs.Review;

namespace ReadingPleasure.API.Controllers
{
    [ApiController]
    [Route(Constants.ApiEndpoints.Reviews.Base)]
    public class ReviewsController: ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet(Constants.ApiEndpoints.Reviews.GetAll)]
        public async Task<IActionResult> GetAll(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            CancellationToken cancellationToken = default)
        {
            var reviews = await _reviewService.GetReviewsAsync(pageNumber, pageSize, cancellationToken);
            return Ok(reviews);
        }

        [HttpGet(Constants.ApiEndpoints.Reviews.GetByBookId)]
        public async Task<IActionResult> GetByBookId(
            [FromRoute] Guid bookId,
            CancellationToken cancellationToken)
        {
            var reviews = await _reviewService.GetReviewsByBookId(bookId, cancellationToken);
            return Ok(reviews);
        }

        [HttpGet(Constants.ApiEndpoints.Reviews.GetByReaderId)]
        public async Task<IActionResult> GetByReaderId(
            [FromRoute] Guid readerId,
            CancellationToken cancellationToken)
        {
            var reviews = await _reviewService.GetReviewsByReaderId(readerId, cancellationToken);
            return Ok(reviews);
        }

        [HttpGet(Constants.ApiEndpoints.Reviews.GetById)]
        public async Task<IActionResult> GetById(
            [FromRoute] Guid id,
            CancellationToken cancellationToken)
        {
            var review = await _reviewService.GetReviewByIdAsync(id, cancellationToken);
            return Ok(review);
        }

        [HttpPost(Constants.ApiEndpoints.Reviews.Create)]
        public async Task<IActionResult> Create(
            [FromBody] CreateReviewDto createReviewDto,
            CancellationToken cancellationToken)
        {
            await _reviewService
                 .CreateReviewAsync(createReviewDto, cancellationToken);
            return NoContent();
        }

        [HttpPut(Constants.ApiEndpoints.Reviews.Update)]
        public async Task<IActionResult> Update(
        [FromRoute] Guid id,
            [FromBody] UpdateReviewDto updateReviewDto,
            CancellationToken cancellationToken)
        {
            await _reviewService.UpdateReviewAsync(id, updateReviewDto, cancellationToken);
            return NoContent();
        }

        [HttpDelete(Constants.ApiEndpoints.Reviews.Delete)]
        public async Task<IActionResult> Delete(
            [FromRoute] Guid id,
            CancellationToken cancellationToken)
        {
            await _reviewService.DeleteReviewAsync(id, cancellationToken);
            return NoContent();
        }
    }
}
