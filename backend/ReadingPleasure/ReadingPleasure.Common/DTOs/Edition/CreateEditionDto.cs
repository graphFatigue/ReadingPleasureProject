

namespace ReadingPleasure.Common.DTOs.Edition
{
    public class CreateEditionDto
    {
        public int YearOfPublication { get; set; }
        public Guid BookId { get; set; }
        public Guid PublishingHouseId { get; set; }
        public string Description { get; set; }
    }
}
