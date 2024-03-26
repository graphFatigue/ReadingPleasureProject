using ReadingPleasure.Domain.Entities;

namespace ReadingPleasure.Abstractions.Application.Services
{
    public interface IJwtService
    {
        Task<string> GenerateTokenAsync(User userEntity);
    }
}
