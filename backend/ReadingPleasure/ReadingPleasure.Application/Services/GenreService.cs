using AutoMapper;
using ReadingPleasure.Abstractions.Application.Services;
using ReadingPleasure.Abstractions.Infrastructure;
using ReadingPleasure.Common.DTOs.Edition;
using ReadingPleasure.Common.DTOs.Genre;
using ReadingPleasure.Common.Exceptions.Editions;
using ReadingPleasure.Common.Exceptions.Genres;
using ReadingPleasure.Common.Utility;
using ReadingPleasure.Domain.Entities;

namespace ReadingPleasure.Application.Services
{
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GenreService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GenreDto> CreateGenreAsync(CreateGenreDto createGenreDto, CancellationToken cancellationToken = default)
        {
            var genre = _mapper.Map<Genre>(createGenreDto);

            await _unitOfWork.GetRepository<IGenreRepository>().AddAsync(genre, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<GenreDto>(genre);
        }

        public async Task DeleteGenreAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var genre = await _unitOfWork
                .GetRepository<IGenreRepository>()
                .GetByIdAsync(id, cancellationToken);
            if (genre is null)
            {
                throw new GenreNotFoundException();
            }

            _unitOfWork.GetRepository<IGenreRepository>().Delete(genre);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<GenreDto?> GetGenreByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var genre = await _unitOfWork
                .GetRepository<IGenreRepository>()
                .GetByIdAsync(id, cancellationToken);
            if (genre is null)
            {
                throw new GenreNotFoundException();
            }

            return _mapper.Map<GenreDto>(genre);
        }

        public async Task<IEnumerable<GenreDto>> GetGenresAsync(int pageNumber = 1, int pageSize = 10, CancellationToken cancellationToken = default)
        {
            var genres = await _unitOfWork.GetRepository<IGenreRepository>()
                .GetAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<GenreDto>>(genres);
        }

        public async Task UpdateGenreAsync(Guid id, UpdateGenreDto updateGenreDto, CancellationToken cancellationToken = default)
        {
            var genre = await _unitOfWork.GetRepository<IGenreRepository>()
                .GetByIdAsync(id, cancellationToken);
            if (genre is null)
            {
                throw new GenreNotFoundException();
            }

            genre.Description = updateGenreDto.Description;
            genre.Name = updateGenreDto.Name;

            _unitOfWork.GetRepository<IGenreRepository>().Update(genre);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
