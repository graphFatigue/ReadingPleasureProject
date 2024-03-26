using ReadingPleasure.Common.DTOs.Author;
using ReadingPleasure.Common.DTOs.Edition;
using ReadingPleasure.Common.DTOs.Genre;
using ReadingPleasure.Common.DTOs.Review;

namespace ReadingPleasure.Common.DTOs.Book
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int PagesCount { get; set; }
        public string Description { get; set; }
        public int YearOfPublication { get; set; }
        public string OriginalLanguage { get; set; }
        public string Language { get; set; }
        public string? Image { get; set; }
        public string? BookFile { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<GenreDto> Genres { get; set; } = new List<GenreDto>();
        public ICollection<AuthorDto> Authors { get; set; } = new List<AuthorDto>();
        public ICollection<EditionDto> Editions { get; set; } = new List<EditionDto>();
        public ICollection<ReviewDto> Reviews { get; set; } = new List<ReviewDto>();
    }
}
