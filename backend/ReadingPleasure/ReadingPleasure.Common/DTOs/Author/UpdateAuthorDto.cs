using ReadingPleasure.Common.DTOs.Book;
using ReadingPleasure.Common.DTOs.Genre;
using ReadingPleasure.Domain.Enum;

namespace ReadingPleasure.Common.DTOs.Author
{
    public class UpdateAuthorDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Biography { get; set; }
        public Sex Sex { get; set; }
        public byte[]? ImageBytes { get; set; }
        public ICollection<GenreDto> Genres { get; set; } = new List<GenreDto>();
        public ICollection<BookDto> Books { get; set; } = new List<BookDto>();
    }
}
