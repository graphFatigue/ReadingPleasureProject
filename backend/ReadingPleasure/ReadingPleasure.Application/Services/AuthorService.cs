using AutoMapper;
using ReadingPleasure.Abstractions.Application.Services;
using ReadingPleasure.Abstractions.Infrastructure;
using ReadingPleasure.Common.DTOs.Author;
using ReadingPleasure.Common.Exceptions.Authors;
using ReadingPleasure.Common.Exceptions.Readers;
using ReadingPleasure.Common.Utility;
using ReadingPleasure.Domain.Entities;

namespace ReadingPleasure.Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IStorageService _blobStorageService;

        public AuthorService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IStorageService blobStorageService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _blobStorageService = blobStorageService;
        }

        public async Task<AuthorDto> CreateAuthorAsync(CreateAuthorDto createAuthorDto, CancellationToken cancellationToken = default)
        {
            var author = _mapper.Map<Author>(createAuthorDto);

            await _unitOfWork.GetRepository<IAuthorRepository>().AddAsync(author, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<AuthorDto>(author);
        }

        public async Task DeleteAuthorAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var author = await _unitOfWork
                .GetRepository<IAuthorRepository>()
                .GetByIdAsync(id, cancellationToken);
            if (author is null)
            {
                throw new AuthorNotFoundException();
            }

            _unitOfWork.GetRepository<IAuthorRepository>().Delete(author);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<AuthorDto?> GetAuthorByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var author = await _unitOfWork
                .GetRepository<IAuthorRepository>()
                .GetByIdAsync(id, cancellationToken);
            if (author is null)
            {
                throw new AuthorNotFoundException();
            }

            return _mapper.Map<AuthorDto>(author);
        }

        public async Task<PaginatedList<AuthorDto>> GetAuthorsAsync(int pageNumber = 1, int pageSize = 10, CancellationToken cancellationToken = default)
        {
            var authors = await _unitOfWork
            .GetRepository<IAuthorRepository>()
            .GetAllAsync(pageNumber, pageSize, cancellationToken);
            var totalCount = await _unitOfWork
                .GetRepository<IAuthorRepository>()
                .GetCountAsync(cancellationToken);

            var authorDtos = _mapper.Map<IEnumerable<AuthorDto>>(authors);

            return new PaginatedList<AuthorDto>(authorDtos, totalCount, pageNumber, pageSize);
        }

        public async Task UpdateAuthorAsync(Guid id, UpdateAuthorDto updateAuthorDto, CancellationToken cancellationToken = default)
        {
            var author = await _unitOfWork.GetRepository<IAuthorRepository>()
                .GetByIdAsync(id, cancellationToken);
            if (author is null)
            {
                throw new ReaderNotFoundException();
            }

            author.FirstName = updateAuthorDto.FirstName;
            author.LastName = updateAuthorDto.LastName;
            author.Biography = updateAuthorDto.Biography;

            _unitOfWork.GetRepository<IAuthorRepository>().Update(author);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
