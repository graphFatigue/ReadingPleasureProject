using ReadingPleasure.Common.DTOs.Author;
using ReadingPleasure.Common.DTOs.Book;

namespace ReadingPleasure.Common.DTOs.Genre
{
    public class GenreDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<AuthorDto> Authors { get; set; } = new List<AuthorDto>();
        public ICollection<BookDto> Books { get; set; } = new List<BookDto>();
    }
}
