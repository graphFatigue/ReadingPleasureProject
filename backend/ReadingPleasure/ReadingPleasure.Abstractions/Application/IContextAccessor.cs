using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingPleasure.Abstractions.Application
{
    public interface IContextAccessor
    {
        Guid GetCurrentUserId();
    }
}
