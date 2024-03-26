using AutoMapper;
using ReadingPleasure.Common.DTOs.User;
using ReadingPleasure.Domain.Entities;

namespace ReadingPleasure.Application.MappingProfiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.ReaderId, src => src.MapFrom(opt => opt.ReaderId));
        }
    }
}
