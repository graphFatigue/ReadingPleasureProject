using AutoMapper;
using ReadingPleasure.Common.DTOs.Roles;
using ReadingPleasure.Domain.Entities;

namespace ReadingPleasure.Application.MappingProfiles
{
    public class RoleMappingProfile : Profile
    {
        public RoleMappingProfile()
        {
            CreateMap<Role, RoleDto>();
            CreateMap<CreateRoleDto, Role>();
        }
    }
}
