
namespace ReadingPleasure.Common.DTOs.Edition
{
    public class EditionDto
    {
        public Guid Id { get; set; }
        public int YearOfPublication { get; set; }
        public Guid BookId { get; set; }
        public Guid PublishingHouseId { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
