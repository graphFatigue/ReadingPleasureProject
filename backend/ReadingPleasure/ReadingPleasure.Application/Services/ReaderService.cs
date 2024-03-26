using AutoMapper;
using ReadingPleasure.Abstractions.Application.Services;
using ReadingPleasure.Abstractions.Infrastructure;
using ReadingPleasure.Common.DTOs.Reader;
using ReadingPleasure.Common.Exceptions.Readers;
using ReadingPleasure.Common.Utility;
using ReadingPleasure.Domain.Entities;

namespace ReadingPleasure.Application.Services
{
    public class ReaderService : IReaderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReaderService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ReaderDto> CreateReaderAsync(CreateReaderDto createReaderDto, CancellationToken cancellationToken = default)
        {
            var reader = _mapper.Map<Reader>(createReaderDto);

            await _unitOfWork.GetRepository<IReaderRepository>().AddAsync(reader, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ReaderDto>(reader);
        }

        public async Task DeleteReaderAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var reader = await _unitOfWork
            .GetRepository<IReaderRepository>()
            .GetByIdAsync(id, cancellationToken);
            if (reader is null)
            {
                throw new Exception("Reader was not found");
            }

            _unitOfWork.GetRepository<IReaderRepository>().Delete(reader);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<ReaderDto?> GetReaderByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var reader = await _unitOfWork
                .GetRepository<IReaderRepository>()
                .GetByIdAsync(id, cancellationToken);
            if (reader is null)
            {
                throw new ReaderNotFoundException();
            }

            return _mapper.Map<ReaderDto>(reader);
        }

        public async Task<PaginatedList<ReaderDto>> GetReadersAsync(int pageNumber = 1, int pageSize = 10, CancellationToken cancellationToken = default)
        {
            var readers = await _unitOfWork
                .GetRepository<IReaderRepository>()
                .GetAllAsync(pageNumber, pageSize, cancellationToken);
            var totalCount = await _unitOfWork
                .GetRepository<IReaderRepository>()
                .GetCountAsync(cancellationToken);

            var readerDtos = _mapper.Map<IEnumerable<ReaderDto>>(readers);

            return new PaginatedList<ReaderDto>(readerDtos, totalCount, pageNumber, pageSize);
        }

        public async Task UpdateReaderAsync(Guid id, UpdateReaderDto updateReaderDto, CancellationToken cancellationToken = default)
        {
            var reader = await _unitOfWork.GetRepository<IReaderRepository>()
                .GetByIdAsync(id, cancellationToken);
            if (reader is null)
            {
                throw new ReaderNotFoundException();
            }

            reader.WordsPerMinute = updateReaderDto.WordsPerMinute;

            _unitOfWork.GetRepository<IReaderRepository>().Update(reader);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
