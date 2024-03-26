using AutoMapper;
using ReadingPleasure.Abstractions.Application.Services;
using ReadingPleasure.Abstractions.Infrastructure;
using ReadingPleasure.Common.DTOs.Book;
using ReadingPleasure.Common.Exceptions.Authors;
using ReadingPleasure.Common.Exceptions.Books;
using ReadingPleasure.Common.Utility;
using ReadingPleasure.Domain.Entities;

namespace ReadingPleasure.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IStorageService _blobStorageService;

        public BookService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IStorageService blobStorageService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _blobStorageService = blobStorageService;
        }

        public async Task<BookDto> CreateBookAsync(CreateBookDto createBookDto, CancellationToken cancellationToken = default)
        {
            var book = _mapper.Map<Book>(createBookDto);

            await _unitOfWork.GetRepository<IBookRepository>().AddAsync(book, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<BookDto>(book);
        }

        public async Task DeleteBookAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var book = await _unitOfWork
                .GetRepository<IBookRepository>()
                .GetByIdAsync(id, cancellationToken);
            if (book is null)
            {
                throw new BookNotFoundException();
            }

            _unitOfWork.GetRepository<IBookRepository>().Delete(book);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<BookDto?> GetBookByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var book = await _unitOfWork
                .GetRepository<IBookRepository>()
                .GetByIdAsync(id, cancellationToken);
            if (book is null)
            {
                throw new BookNotFoundException();
            }

            return _mapper.Map<BookDto>(book);
        }

        public async Task<PaginatedList<BookDto>> GetBooksAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            var books = await _unitOfWork
                .GetRepository<IBookRepository>()
                .GetAllAsync(pageNumber, pageSize, cancellationToken);
            var totalCount = await _unitOfWork
                .GetRepository<IBookRepository>()
                .GetCountAsync(cancellationToken);

            var bookDtos = _mapper.Map<IEnumerable<BookDto>>(books);

            return new PaginatedList<BookDto>(bookDtos, totalCount, pageNumber, pageSize);
        }

        public async Task<IEnumerable<BookDto>> GetBooksByAuthorId(Guid authorId, CancellationToken cancellationToken = default)
        {
            var author = await _unitOfWork.GetRepository<IAuthorRepository>()
                .GetByIdAsync(authorId, cancellationToken);
            if (author is null)
            {
                throw new AuthorNotFoundException();
            }

            var books = await _unitOfWork.GetRepository<IBookRepository>()
                .GetByAuthorIdAsync(authorId, cancellationToken);

            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public async Task UpdateBookAsync(Guid id, UpdateBookDto updateBookDto, CancellationToken cancellationToken = default)
        {
            var book = await _unitOfWork.GetRepository<IBookRepository>()
                .GetByIdAsync(id, cancellationToken);
            if (book is null)
            {
                throw new BookNotFoundException();
            }

            book.Title = updateBookDto.Title;
            book.Description = updateBookDto.Description;
            book.YearOfPublication = updateBookDto.YearOfPublication;
            book.OriginalLanguage = updateBookDto.OriginalLanguage;
            book.Language = updateBookDto.Language;

            _unitOfWork.GetRepository<IBookRepository>().Update(book);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
