using Microsoft.EntityFrameworkCore;
using ReadingPleasure.Abstractions.Infrastructure;
using ReadingPleasure.Domain.Entities;

namespace ReadingPleasure.Infrastructure.Repositories
{
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        public ReviewRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Review>> GetAllAsync(int skip, int take, CancellationToken cancellationToken = default)
        {
            return await DbSet
                .Skip(skip)
                .Take(take)
                .ToListAsync(cancellationToken);
        }

        public override async Task<Review?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await DbSet
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<Review>> GetByBookIdAsync(Guid bookId, CancellationToken cancellationToken = default)
        {
            return await DbSet
                .Where(x => x.BookId == bookId)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Review>> GetByReaderIdAsync(Guid readerId, CancellationToken cancellationToken = default)
        {
            return await DbSet
                .Where(x => x.ReaderId == readerId)
                .ToListAsync(cancellationToken);
        }

        public async Task<int> GetCountAsync(CancellationToken cancellationToken = default)
        {
            return await DbSet.CountAsync(cancellationToken);
        }
    }
}
