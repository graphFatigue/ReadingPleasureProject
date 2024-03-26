using Microsoft.EntityFrameworkCore;
using ReadingPleasure.Abstractions.Infrastructure;
using ReadingPleasure.Domain.Entities;

namespace ReadingPleasure.Infrastructure.Repositories
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Author>> GetAllAsync(int pageNumber = 1, int pageSize = 10, CancellationToken cancellationToken = default)
        {
            return await DbSet
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Include(x => x.Books)
                .ToListAsync(cancellationToken);
        }

        public override async Task<Author?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await DbSet
                .Include(x => x.Books)
                .Include(x => x.Genres)
                .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, cancellationToken); ;
        }

        public async Task<int> GetCountAsync(CancellationToken cancellationToken = default)
        {
            return await DbSet.CountAsync(cancellationToken);
        }
    }
}
