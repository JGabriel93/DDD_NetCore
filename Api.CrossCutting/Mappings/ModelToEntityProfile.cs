using Api.Domain.Entities.CurrentAccount;
using Api.Domain.Entities.User;
using Api.Domain.Models.CurrentAccount;
using Api.Domain.Models.User;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<UserEntity, UserModel>().ReverseMap();
            CreateMap<CurrentAccountEntity, CurrentAccountModel>().ReverseMap();
            CreateMap<HistoricCurrentAccountEntity, HistoricCurrentAccountModel>().ReverseMap();
        }
    }
}
