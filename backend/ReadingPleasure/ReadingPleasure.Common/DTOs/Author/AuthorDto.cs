using ReadingPleasure.Common.DTOs.Book;
using ReadingPleasure.Common.DTOs.Genre;
using ReadingPleasure.Domain.Enum;

namespace ReadingPleasure.Common.DTOs.Author
{
    public class AuthorDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Biography { get; set; }
        public Sex Sex { get; set; }
        public string? Image { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<GenreDto> Genres { get; set; } = new List<GenreDto>();
        public ICollection<BookDto> Books { get; set; } = new List<BookDto>();
    }
}
