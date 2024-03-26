using Microsoft.EntityFrameworkCore;
using ReadingPleasure.Abstractions.Infrastructure;
using ReadingPleasure.Domain.Entities;

namespace ReadingPleasure.Infrastructure.Repositories
{
    public class ReaderRepository : GenericRepository<Reader>, IReaderRepository
    {
        public ReaderRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Reader>> GetAllAsync(
            int pageNumber = 1,
            int pageSize = 10,
            CancellationToken cancellationToken = default)
        {
            return await DbSet
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Include(x => x.FavoriteGenres)
                .Include(x => x.FavoriteBooks)
                .Include(x => x.FavoriteAuthors)
                .Include(x => x.Reviews)
                .ToListAsync(cancellationToken);
        }

        public async Task<int> GetCountAsync(CancellationToken cancellationToken = default)
        {
            return await DbSet.CountAsync(cancellationToken);
        }
    }
}
