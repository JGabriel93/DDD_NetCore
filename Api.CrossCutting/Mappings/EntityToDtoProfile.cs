using Api.Domain.Dtos.CurrentAccount;
using Api.Domain.Dtos.Transaction;
using Api.Domain.Dtos.User;
using Api.Domain.Entities.CurrentAccount;
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
            CreateMap<CurrentAccountDtoResult, CurrentAccountEntity>().ReverseMap();
            CreateMap<HistoricCurrentAccountDtoResult, HistoricCurrentAccountEntity>().ReverseMap();
        }
    }
}
