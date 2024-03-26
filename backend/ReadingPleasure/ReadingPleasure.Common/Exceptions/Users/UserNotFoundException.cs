using ReadingPleasure.Common.Exceptions.Shared;

namespace ReadingPleasure.Common.Exceptions.Users
{
    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException() : base("User was not found")
        {
        }
    }
}
