using AutoMapper;
using ReadingPleasure.Abstractions.Application.Services;
using ReadingPleasure.Abstractions.Infrastructure;
using ReadingPleasure.Common.DTOs.Review;
using ReadingPleasure.Common.Exceptions.Books;
using ReadingPleasure.Common.Exceptions.Readers;
using ReadingPleasure.Common.Exceptions.Reviews;
using ReadingPleasure.Common.Utility;
using ReadingPleasure.Domain.Entities;

namespace ReadingPleasure.Application.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReviewService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ReviewDto> CreateReviewAsync(CreateReviewDto createReviewDto, CancellationToken cancellationToken = default)
        {
            var review = _mapper.Map<Review>(createReviewDto);

            await _unitOfWork.GetRepository<IReviewRepository>().AddAsync(review, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ReviewDto>(review);
        }

        public async Task DeleteReviewAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var review = await _unitOfWork
                .GetRepository<IReviewRepository>()
                .GetByIdAsync(id, cancellationToken);
            if (review is null)
            {
                throw new ReviewNotFoundException();
            }

            _unitOfWork.GetRepository<IReviewRepository>().Delete(review);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<ReviewDto?> GetReviewByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var review = await _unitOfWork
                .GetRepository<IReviewRepository>()
                .GetByIdAsync(id, cancellationToken);
            if (review is null)
            {
                throw new ReviewNotFoundException();
            }

            return _mapper.Map<ReviewDto>(review);
        }

        public async Task<PaginatedList<ReviewDto>> GetReviewsAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            var reviews = await _unitOfWork
                .GetRepository<IReviewRepository>()
                .GetAllAsync(pageNumber, pageSize, cancellationToken);
            var totalCount = await _unitOfWork
                .GetRepository<IReviewRepository>()
                .GetCountAsync(cancellationToken);

            var reviewDtos = _mapper.Map<IEnumerable<ReviewDto>>(reviews);

            return new PaginatedList<ReviewDto>(reviewDtos, totalCount, pageNumber, pageSize);
        }

        public async Task<IEnumerable<ReviewDto>> GetReviewsByBookId(Guid bookId, CancellationToken cancellationToken = default)
        {
            var book = await _unitOfWork.GetRepository<IBookRepository>()
                .GetByIdAsync(bookId, cancellationToken);
            if (book is null)
            {
                throw new BookNotFoundException();
            }

            var reviews = await _unitOfWork.GetRepository<IReviewRepository>()
                .GetByBookIdAsync(bookId, cancellationToken);

            return _mapper.Map<IEnumerable<ReviewDto>>(reviews);
        }

        public async Task<IEnumerable<ReviewDto>> GetReviewsByReaderId(Guid readerId, CancellationToken cancellationToken = default)
        {
            var reader = await _unitOfWork.GetRepository<IReaderRepository>()
                .GetByIdAsync(readerId, cancellationToken);
            if (reader is null)
            {
                throw new ReaderNotFoundException();
            }

            var reviews = await _unitOfWork.GetRepository<IReviewRepository>()
                .GetByBookIdAsync(readerId, cancellationToken);

            return _mapper.Map<IEnumerable<ReviewDto>>(reviews);
        }

        public async Task UpdateReviewAsync(Guid id, UpdateReviewDto updateReviewDto, CancellationToken cancellationToken = default)
        {
            var review = await _unitOfWork.GetRepository<IReviewRepository>()
                .GetByIdAsync(id, cancellationToken);
            if (review is null)
            {
                throw new ReviewNotFoundException();
            }

            review.Content = updateReviewDto.Content;

            _unitOfWork.GetRepository<IReviewRepository>().Update(review);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
