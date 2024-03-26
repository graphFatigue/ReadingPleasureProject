using ReadingPleasure.Common.DTOs.PublishingHouse;
using ReadingPleasure.Common.Utility;


namespace ReadingPleasure.Abstractions.Application.Services
{
    public interface IPublishingHouseService
    {
        Task<IEnumerable<PublishingHouseDto>> GetPublishingHousesAsync(int pageNumber = 1, int pageSize = 10,
CancellationToken cancellationToken = default);
        Task<PublishingHouseDto?> GetPublishingHouseByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<PublishingHouseDto> CreatePublishingHouseAsync(CreatePublishingHouseDto createPublishingHouseDto,
            CancellationToken cancellationToken = default);
        Task UpdatePublishingHouseAsync(Guid id, UpdatePublishingHouseDto updatePublishingHouseDto,
            CancellationToken cancellationToken = default);
        Task DeletePublishingHouseAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
