using ReadingPleasure.Common.DTOs.Book;
using ReadingPleasure.Common.Utility;

namespace ReadingPleasure.Abstractions.Application.Services
{
    public interface IBookService
    {
        Task<PaginatedList<BookDto>> GetBooksAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default);
        Task<IEnumerable<BookDto>> GetBooksByAuthorId(Guid authorId, CancellationToken cancellationToken = default);
        Task<BookDto?> GetBookByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<BookDto> CreateBookAsync(CreateBookDto createBookDto,
            CancellationToken cancellationToken = default);
        Task UpdateBookAsync(Guid id, UpdateBookDto updateBookDto,
            CancellationToken cancellationToken = default);
        Task DeleteBookAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
