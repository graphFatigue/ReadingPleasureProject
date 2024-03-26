using ReadingPleasure.Common.DTOs.Edition;
using ReadingPleasure.Common.Utility;

namespace ReadingPleasure.Abstractions.Application.Services
{
    public interface IEditionService
    {
        Task<IEnumerable<EditionDto>> GetEditionsAsync(int pageNumber = 1, int pageSize = 10,
CancellationToken cancellationToken = default);
        Task<EditionDto?> GetEditionByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<EditionDto> CreateEditionAsync(CreateEditionDto createEditionDto,
            CancellationToken cancellationToken = default);
        Task UpdateEditionAsync(Guid id, UpdateEditionDto updateEditionDto,
            CancellationToken cancellationToken = default);
        Task DeleteEditionAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
