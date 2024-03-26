using ReadingPleasure.Domain.Enum;

namespace ReadingPleasure.Common.DTOs.User
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Sex Sex { get; set; }
        public string? Image { get; set; }
        public Guid ReaderId { get; set; }
    }
}
