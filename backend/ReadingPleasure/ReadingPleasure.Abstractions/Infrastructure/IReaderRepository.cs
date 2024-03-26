using ReadingPleasure.Domain.Entities;

namespace ReadingPleasure.Abstractions.Infrastructure
{
    public interface IReaderRepository : IGenericRepository<Reader>
    {
        Task<IEnumerable<Reader>> GetAllAsync(int pageNumber = 1, int pageSize = 10, CancellationToken cancellationToken = default);
        Task<int> GetCountAsync(CancellationToken cancellationToken = default);
    }
}
