using AutoMapper;
using ReadingPleasure.Common.DTOs.Reader;
using ReadingPleasure.Domain.Entities;

namespace ReadingPleasure.Application.MappingProfiles
{
    public class ReaderMappingProfile : Profile
    {
        public ReaderMappingProfile()
        {
            CreateMap<Reader, ReaderDto>();
            CreateMap<CreateReaderDto, Reader>();
        }
    }
}
