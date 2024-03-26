using ReadingPleasure.Domain.Entities;

namespace ReadingPleasure.Abstractions.Infrastructure
{
    public interface IReviewRepository : IGenericRepository<Review>
    {
        Task<IEnumerable<Review>> GetAllAsync(int skip, int take, CancellationToken cancellationToken = default);
        Task<IEnumerable<Review>> GetByBookIdAsync(Guid bookId, CancellationToken cancellationToken = default);
        Task<IEnumerable<Review>> GetByReaderIdAsync(Guid readerId, CancellationToken cancellationToken = default);
        Task<int> GetCountAsync(CancellationToken cancellationToken = default);
    }
}
