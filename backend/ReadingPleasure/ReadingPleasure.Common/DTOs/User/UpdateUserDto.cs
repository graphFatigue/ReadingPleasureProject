using ReadingPleasure.Domain.Enum;

namespace ReadingPleasure.Common.DTOs.User
{
    public class UpdateUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Sex Sex { get; set; }
        public byte[]? ImageBytes { get; set; }
    }
}
