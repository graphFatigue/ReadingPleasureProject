using AutoMapper;
using ReadingPleasure.Abstractions.Application.Services;
using ReadingPleasure.Abstractions.Infrastructure;
using ReadingPleasure.Common.DTOs.PublishingHouse;
using ReadingPleasure.Common.Exceptions.Editions;
using ReadingPleasure.Common.Exceptions.PublishingHouses;
using ReadingPleasure.Domain.Entities;

namespace ReadingPleasure.Application.Services
{
    public class PublishingHouseService : IPublishingHouseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PublishingHouseService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PublishingHouseDto> CreatePublishingHouseAsync(CreatePublishingHouseDto createPublishingHouseDto, CancellationToken cancellationToken = default)
        {
            var publishingHouse = _mapper.Map<PublishingHouse>(createPublishingHouseDto);

            await _unitOfWork.GetRepository<IPublishingHouseRepository>().AddAsync(publishingHouse, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<PublishingHouseDto>(publishingHouse);
        }

        public async Task DeletePublishingHouseAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var publishingHouse = await _unitOfWork
                .GetRepository<IPublishingHouseRepository>()
                .GetByIdAsync(id, cancellationToken);
            if (publishingHouse is null)
            {
                throw new PublishingHouseNotFoundException();
            }

            _unitOfWork.GetRepository<IPublishingHouseRepository>().Delete(publishingHouse);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<PublishingHouseDto?> GetPublishingHouseByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var publishingHouse = await _unitOfWork
                .GetRepository<IPublishingHouseRepository>()
                .GetByIdAsync(id, cancellationToken);
            if (publishingHouse is null)
            {
                throw new PublishingHouseNotFoundException();
            }

            return _mapper.Map<PublishingHouseDto>(publishingHouse);
        }

        public async Task<IEnumerable<PublishingHouseDto>> GetPublishingHousesAsync(int pageNumber = 1, int pageSize = 10, CancellationToken cancellationToken = default)
        {
            var publishingHouses = await _unitOfWork.GetRepository<IPublishingHouseRepository>()
                .GetAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<PublishingHouseDto>>(publishingHouses);
        }

        public async Task UpdatePublishingHouseAsync(Guid id, UpdatePublishingHouseDto updatePublishingHouseDto, CancellationToken cancellationToken = default)
        {
            var publishingHouse = await _unitOfWork.GetRepository<IPublishingHouseRepository>()
                .GetByIdAsync(id, cancellationToken);
            if (publishingHouse is null)
            {
                throw new EditionNotFoundException();
            }

            publishingHouse.Information = updatePublishingHouseDto.Information;
            publishingHouse.Name = updatePublishingHouseDto.Name;

            _unitOfWork.GetRepository<IPublishingHouseRepository>().Update(publishingHouse);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
