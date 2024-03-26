

namespace ReadingPleasure.Common.DTOs.Review
{
    public class ReviewDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
        public Guid ReaderId { get; set; }
        public Guid BookId { get; set; }
    }
}
