using AutoMapper;
using ReadingPleasure.Common.DTOs.Author;
using ReadingPleasure.Domain.Entities;

namespace ReadingPleasure.Application.MappingProfiles
{
    public class AuthorMappingProfile: Profile
    {
        public AuthorMappingProfile()
        {
            CreateMap<Author, AuthorDto>();
            CreateMap<CreateAuthorDto, Author>();
        }    
    }
}
