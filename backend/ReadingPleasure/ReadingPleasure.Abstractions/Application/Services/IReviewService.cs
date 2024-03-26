using ReadingPleasure.Common.DTOs.Review;
using ReadingPleasure.Common.Utility;

namespace ReadingPleasure.Abstractions.Application.Services
{
    public interface IReviewService
    {
        Task<PaginatedList<ReviewDto>> GetReviewsAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default);
        Task<IEnumerable<ReviewDto>> GetReviewsByReaderId(Guid readerId, CancellationToken cancellationToken = default);
        Task<IEnumerable<ReviewDto>> GetReviewsByBookId(Guid bookId, CancellationToken cancellationToken = default);
        Task<ReviewDto?> GetReviewByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<ReviewDto> CreateReviewAsync(CreateReviewDto createReviewDto,
            CancellationToken cancellationToken = default);
        Task UpdateReviewAsync(Guid id, UpdateReviewDto updateReviewDto,
            CancellationToken cancellationToken = default);
        Task DeleteReviewAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
