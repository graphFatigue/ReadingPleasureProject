using ReadingPleasure.Abstractions.Infrastructure;
using ReadingPleasure.Domain.Entities;

namespace ReadingPleasure.Infrastructure.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(AppDbContext context) : base(context)
        {
        }
    }
}
