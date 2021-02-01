using Api.Domain.Dtos.User;
using Api.Domain.Entities.User;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<UserDto, UserEntity>().ReverseMap();
            CreateMap<UserDtoResult, UserEntity>().ReverseMap();
        }
    }
}
