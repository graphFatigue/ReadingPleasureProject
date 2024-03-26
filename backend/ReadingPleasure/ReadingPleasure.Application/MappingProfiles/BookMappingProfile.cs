using AutoMapper;
using ReadingPleasure.Common.DTOs.Book;
using ReadingPleasure.Domain.Entities;

namespace ReadingPleasure.Application.MappingProfiles
{
    public class BookMappingProfile : Profile
    {
        public BookMappingProfile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<CreateBookDto, Book>();
        }
    }
}
