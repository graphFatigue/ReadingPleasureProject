using ReadingPleasure.Common.DTOs.Author;
using ReadingPleasure.Common.DTOs.Book;
using ReadingPleasure.Common.DTOs.Genre;
using ReadingPleasure.Common.DTOs.Review;

namespace ReadingPleasure.Common.DTOs.Reader
{
    public class ReaderDto
    {
        public Guid Id { get; set; }
        public int WordsPerMinute { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
        public Guid UserId { get; set; }
        public ICollection<GenreDto> FavoriteGenres { get; set; } = new List<GenreDto>();
        public ICollection<BookDto> FavoriteBooks { get; set; } = new List<BookDto>();
        public ICollection<AuthorDto> FavoriteAuthors { get; set; } = new List<AuthorDto>();
        public ICollection<ReviewDto> Reviews { get; set; } = new List<ReviewDto>();
    }
}
