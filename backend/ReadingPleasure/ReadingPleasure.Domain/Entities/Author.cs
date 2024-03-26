using ReadingPleasure.Domain.Enum;

namespace ReadingPleasure.Domain.Entities
{
    public class Author : IBaseEntity
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

        public ICollection<Genre> Genres { get; set; } = new List<Genre>();
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
