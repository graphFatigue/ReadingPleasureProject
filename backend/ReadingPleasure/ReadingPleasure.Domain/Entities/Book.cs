namespace ReadingPleasure.Domain.Entities
{
    public class Book : IBaseEntity
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

        public ICollection<Genre> Genres { get; set; } = new List<Genre>();
        public ICollection<Author> Authors { get; set; } = new List<Author>();
        public ICollection<Edition> Editions { get; set; } = new List<Edition>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
