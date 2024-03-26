
namespace ReadingPleasure.Common.DTOs.Review
{
    public class UpdateReviewDto
    {
        public string Content { get; set; }
        public Guid ReaderId { get; set; }
        public Guid BookId { get; set; }
    }
}
