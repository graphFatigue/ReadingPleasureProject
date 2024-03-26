using AutoMapper;
using ReadingPleasure.Common.DTOs.Edition;
using ReadingPleasure.Domain.Entities;

namespace ReadingPleasure.Application.MappingProfiles
{
    public class EditionMappingProfile : Profile
    {
        public EditionMappingProfile()
        {
            CreateMap<Edition, EditionDto>();
            CreateMap<CreateEditionDto, Edition>();
        }
    }
}
