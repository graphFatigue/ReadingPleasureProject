namespace ReadingPleasure.Domain.Entities
{
    public class Genre : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Author> Authors { get; set; } = new List<Author>();
        public ICollection<Book> Books { get; set; } = new List<Book>();

    }
}
