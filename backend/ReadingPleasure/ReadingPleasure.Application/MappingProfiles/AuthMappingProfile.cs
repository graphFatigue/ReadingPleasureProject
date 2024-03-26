using AutoMapper;
using ReadingPleasure.Common.DTOs.Auth;
using ReadingPleasure.Domain.Entities;

namespace ReadingPleasure.Application.MappingProfiles
{
    public class AuthMappingProfile : Profile
    {
        public AuthMappingProfile()
        {
            CreateMap<SignupDto, User>()
                .ForMember(dest => dest.UserName, src => src.MapFrom(opt => opt.Email));
        }
    }
}
