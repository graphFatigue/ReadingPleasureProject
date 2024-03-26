using AutoMapper;
using ReadingPleasure.Common.DTOs.PublishingHouse;
using ReadingPleasure.Domain.Entities;

namespace ReadingPleasure.Application.MappingProfiles
{
    public class PublishingHouseMappingProfile : Profile
    {
        public PublishingHouseMappingProfile()
        {
            CreateMap<PublishingHouse, PublishingHouseDto>();
            CreateMap<CreatePublishingHouseDto, PublishingHouse>();
        }
    }
}
