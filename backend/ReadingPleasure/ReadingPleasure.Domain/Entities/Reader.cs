namespace ReadingPleasure.Domain.Entities
{
    public class Reader : IBaseEntity
    {
        public Guid Id { get; set; }
        public int WordsPerMinute { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public ICollection<Genre> FavoriteGenres { get; set; } = new List<Genre>();
        public ICollection<Book> FavoriteBooks { get; set; } = new List<Book>();
        public ICollection<Author> FavoriteAuthors { get; set; } = new List<Author>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();

    }
}
