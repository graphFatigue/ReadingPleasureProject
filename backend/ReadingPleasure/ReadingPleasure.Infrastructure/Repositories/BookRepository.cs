using Microsoft.EntityFrameworkCore;
using ReadingPleasure.Abstractions.Infrastructure;
using ReadingPleasure.Domain.Entities;

namespace ReadingPleasure.Infrastructure.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Book>> GetAllAsync(int skip, int take, CancellationToken cancellationToken = default)
        {
            return await DbSet
                .Skip(skip)
                .Take(take)
                .Include(x => x.Authors)
                .Include(x => x.Editions)
                .Include(x => x.Reviews)
                .Include(x => x.Genres)
                .ToListAsync(cancellationToken);
        }

        public override async Task<Book?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await DbSet
                .Include(x => x.Authors)
                .Include(x => x.Editions)
                .Include(x => x.Reviews)
                .Include(x => x.Genres)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<Book>> GetByAuthorIdAsync(Guid authorId, CancellationToken cancellationToken = default)
        {
            return await DbSet
                .Where(x => x.Authors.Where(x => x.Id == authorId).Count() >=1)
                .Include(x => x.Authors)
                .Include(x => x.Editions)
                .Include(x => x.Reviews)
                .Include(x => x.Genres)
                .ToListAsync(cancellationToken);
        }

        public async Task<int> GetCountAsync(CancellationToken cancellationToken = default)
        {
            return await DbSet.CountAsync(cancellationToken);
        }
    }
}
