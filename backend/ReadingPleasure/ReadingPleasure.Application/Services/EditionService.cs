using AutoMapper;
using ReadingPleasure.Abstractions.Application.Services;
using ReadingPleasure.Abstractions.Infrastructure;
using ReadingPleasure.Common.DTOs.Edition;
using ReadingPleasure.Common.Exceptions.Editions;
using ReadingPleasure.Domain.Entities;

namespace ReadingPleasure.Application.Services
{
    public class EditionService : IEditionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EditionService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<EditionDto> CreateEditionAsync(CreateEditionDto createEditionDto, CancellationToken cancellationToken = default)
        {
            var edition = _mapper.Map<Edition>(createEditionDto);

            await _unitOfWork.GetRepository<IEditionRepository>().AddAsync(edition, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<EditionDto>(edition);
        }

        public async Task DeleteEditionAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var edition = await _unitOfWork
                .GetRepository<IEditionRepository>()
                .GetByIdAsync(id, cancellationToken);
            if (edition is null)
            {
                throw new EditionNotFoundException();
            }

            _unitOfWork.GetRepository<IEditionRepository>().Delete(edition);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<EditionDto?> GetEditionByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var edition = await _unitOfWork
                .GetRepository<IEditionRepository>()
                .GetByIdAsync(id, cancellationToken);
            if (edition is null)
            {
                throw new EditionNotFoundException();
            }

            return _mapper.Map<EditionDto>(edition);
        }

        public async Task<IEnumerable<EditionDto>> GetEditionsAsync(int pageNumber = 1, int pageSize = 10, CancellationToken cancellationToken = default)
        {
            var editions = await _unitOfWork.GetRepository<IEditionRepository>()
                .GetAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<EditionDto>>(editions);
        }

        public async Task UpdateEditionAsync(Guid id, UpdateEditionDto updateEditionDto, CancellationToken cancellationToken = default)
        {
            var edition = await _unitOfWork.GetRepository<IEditionRepository>()
                .GetByIdAsync(id, cancellationToken);
            if (edition is null)
            {
                throw new EditionNotFoundException();
            }

            edition.Description = updateEditionDto.Description;
            edition.YearOfPublication = updateEditionDto.YearOfPublication;

            _unitOfWork.GetRepository<IEditionRepository>().Update(edition);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
