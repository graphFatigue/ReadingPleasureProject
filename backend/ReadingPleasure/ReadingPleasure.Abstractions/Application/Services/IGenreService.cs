using ReadingPleasure.Common.DTOs.Genre;
using ReadingPleasure.Common.Utility;


namespace ReadingPleasure.Abstractions.Application.Services
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreDto>> GetGenresAsync(int pageNumber = 1, int pageSize = 10,
CancellationToken cancellationToken = default);
        Task<GenreDto?> GetGenreByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<GenreDto> CreateGenreAsync(CreateGenreDto createGenreDto,
            CancellationToken cancellationToken = default);
        Task UpdateGenreAsync(Guid id, UpdateGenreDto updateGenreDto,
            CancellationToken cancellationToken = default);
        Task DeleteGenreAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
