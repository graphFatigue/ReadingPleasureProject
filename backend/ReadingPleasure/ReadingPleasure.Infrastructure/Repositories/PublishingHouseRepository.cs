using Microsoft.EntityFrameworkCore;
using ReadingPleasure.Abstractions.Infrastructure;
using ReadingPleasure.Domain.Entities;

namespace ReadingPleasure.Infrastructure.Repositories
{
    public class PublishingHouseRepository : GenericRepository<PublishingHouse>, IPublishingHouseRepository
    {
        public PublishingHouseRepository(AppDbContext context) : base(context)
        {
        }

        public override async Task<PublishingHouse?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await DbSet
                .Include(x => x.Editions)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
