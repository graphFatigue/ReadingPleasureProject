using ReadingPleasure.Domain.Entities;

namespace ReadingPleasure.Abstractions.Infrastructure
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetByEmailAsync(
    string email,
    CancellationToken cancellationToken = default);
    }
}
