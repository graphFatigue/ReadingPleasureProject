using ReadingPleasure.Common.Exceptions.Shared;

namespace ReadingPleasure.Common.Exceptions.Permissions
{
    public class PermissionNotFoundException : NotFoundException
    {
        public PermissionNotFoundException() : base("Permission was not found")
        {
        }
    }
}
