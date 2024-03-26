using ReadingPleasure.Abstractions.Infrastructure;
using ReadingPleasure.Domain.Entities;

namespace ReadingPleasure.Infrastructure.Repositories
{
    public class EditionRepository : GenericRepository<Edition>, IEditionRepository
    {
        public EditionRepository(AppDbContext context) : base(context)
        {
        }
    }
}
