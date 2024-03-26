using ReadingPleasure.Common.DTOs.Reader;
using ReadingPleasure.Common.Utility;

namespace ReadingPleasure.Abstractions.Application.Services
{
    public interface IReaderService
    {
        Task<PaginatedList<ReaderDto>> GetReadersAsync(int pageNumber = 1, int pageSize = 10,
    CancellationToken cancellationToken = default);
        Task<ReaderDto?> GetReaderByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<ReaderDto> CreateReaderAsync(CreateReaderDto createReaderDto,
            CancellationToken cancellationToken = default);
        Task UpdateReaderAsync(Guid id, UpdateReaderDto updateReaderDto,
            CancellationToken cancellationToken = default);
        Task DeleteReaderAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
