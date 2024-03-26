namespace ReadingPleasure.Domain.Entities
{
    public class Review : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
        public Guid ReaderId { get; set; }
        public Reader Reader { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
    }
}
