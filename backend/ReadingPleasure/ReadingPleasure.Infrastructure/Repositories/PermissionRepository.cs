using Microsoft.EntityFrameworkCore;
using ReadingPleasure.Abstractions.Infrastructure;
using ReadingPleasure.Domain.Entities;

namespace ReadingPleasure.Infrastructure.Repositories
{
    public class PermissionRepository : GenericRepository<Permission>, IPermissionRepository
    {
        public PermissionRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Permission>> GetByIdsAsync(List<Guid> ids, CancellationToken cancellationToken = default)
        {
            return await DbSet
                .Where(x => ids.Contains(x.Id))
                .ToListAsync(cancellationToken);
        }
    }
}
