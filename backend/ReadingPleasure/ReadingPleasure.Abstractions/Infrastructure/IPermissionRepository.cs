using ReadingPleasure.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingPleasure.Abstractions.Infrastructure
{
    public interface IPermissionRepository : IGenericRepository<Permission>
    {
        Task<IEnumerable<Permission>> GetByIdsAsync(List<Guid> ids, CancellationToken cancellationToken = default);
    }
}
