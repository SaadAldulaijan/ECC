using AutoMapper;
using ECC.Models;
using ECC.Shared.Users.Contracts;

namespace ECC.Users.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserResponseDto>()
                .ForMember(x => x.GroupName, src => src.MapFrom(map => map.Group.Name));
            //CreateMap<User, UserRequestDto>();
        }
    }
}
