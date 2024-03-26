using ReadingPleasure.Common.Exceptions.Shared;

namespace ReadingPleasure.Common.Exceptions.Roles
{
    public class RoleNotFoundException : NotFoundException
    {
        public RoleNotFoundException() : base("Role was not found")
        {
        }
    }
}
