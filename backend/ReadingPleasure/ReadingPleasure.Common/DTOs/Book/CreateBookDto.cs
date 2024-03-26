using ReadingPleasure.Common.DTOs.Author;
using ReadingPleasure.Common.DTOs.Genre;

namespace ReadingPleasure.Common.DTOs.Book
{
    public class CreateBookDto
    {
        public string Title { get; set; }
        public int PagesCount { get; set; }
        public string Description { get; set; }
        public int YearOfPublication { get; set; }
        public string OriginalLanguage { get; set; }
        public string Language { get; set; }
        public byte[]? ImageBytes { get; set; }
        public byte[]? BookFileBytes { get; set; }

        public ICollection<GenreDto> Genres { get; set; } = new List<GenreDto>();
        public ICollection<AuthorDto> Authors { get; set; } = new List<AuthorDto>();
    }
}
