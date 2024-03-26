using ReadingPleasure.Common.DTOs.Author;
using ReadingPleasure.Common.Utility;

namespace ReadingPleasure.Abstractions.Application.Services
{
    public interface IAuthorService
    {
        Task<PaginatedList<AuthorDto>> GetAuthorsAsync(int pageNumber = 1, int pageSize = 10,
CancellationToken cancellationToken = default);
        Task<AuthorDto?> GetAuthorByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<AuthorDto> CreateAuthorAsync(CreateAuthorDto createAuthorDto,
            CancellationToken cancellationToken = default);
        Task UpdateAuthorAsync(Guid id, UpdateAuthorDto updateAuthorDto,
            CancellationToken cancellationToken = default);
        Task DeleteAuthorAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
