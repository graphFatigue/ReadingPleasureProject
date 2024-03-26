using ReadingPleasure.Common.DTOs.Edition;

namespace ReadingPleasure.Common.DTOs.PublishingHouse
{
    public class PublishingHouseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Information { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<EditionDto> Editions { get; set; } = new List<EditionDto>();
    }
}
