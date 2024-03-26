using AutoMapper;
using ReadingPleasure.Common.DTOs.Genre;
using ReadingPleasure.Domain.Entities;

namespace ReadingPleasure.Application.MappingProfiles
{
    public class GenreMappingProfile : Profile
    {
        public GenreMappingProfile()
        {
            CreateMap<Genre, GenreDto>();
            CreateMap<CreateGenreDto, Genre>();
        }
    }
}
