using Microsoft.AspNetCore.Identity;
using ReadingPleasure.Domain.Enum;

namespace ReadingPleasure.Domain.Entities
{
    public class User : IdentityUser<Guid>, IBaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Sex Sex { get; set; }
        public string? Image { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
        public Guid ReaderId { get; set; }
        public Reader Reader { get; set; }
    }
}
