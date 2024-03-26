using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingPleasure.Common.DTOs.Roles
{
    public class RemovePermissionFromRoleDto
    {
        public List<Guid> PermissionIds { get; set; }
    }
}
