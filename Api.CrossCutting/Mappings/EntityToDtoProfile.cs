using Api.Domain.Dtos.CurrentAccount;
using Api.Domain.Dtos.Transaction;
using Api.Domain.Dtos.User;
using Api.Domain.Entities.CurrentAccount;
using Api.Domain.Entities.User;
using Api.Domain.Mappings;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<UserDto, UserEntity>().ReverseMap();
            CreateMap<UserDtoResult, UserEntity>().ReverseMap();
            CreateMap<CurrentAccountEntity, CurrentAccountDtoResult>().AfterMap((src, dest) =>
            {
                dest.UpdateAt = src.UpdateAt == null ? "" : src.UpdateAt?.ToString("dd/MM/yyyy HH:mm:ss");
            });
            CreateMap<HistoricCurrentAccountEntity, HistoricCurrentAccountDtoResult>().AfterMap((src, dest) =>
            {
                dest.CreateAt = src.CreateAt?.ToString("dd/MM/yyyy HH:mm:ss");

                dest.Movement = src.Movement.Equals(HistoricCurrentAccountMapper.Description.Deposit.Key) ? HistoricCurrentAccountMapper.Description.Deposit.Description
                : src.Movement.Equals(HistoricCurrentAccountMapper.Description.Payment.Key) ? HistoricCurrentAccountMapper.Description.Payment.Description
                : src.Movement.Equals(HistoricCurrentAccountMapper.Description.Transfer.Key) ? HistoricCurrentAccountMapper.Description.Transfer.Description
                : src.Movement.Equals(HistoricCurrentAccountMapper.Description.TransferReceived.Key) ? HistoricCurrentAccountMapper.Description.TransferReceived.Description
                : src.Movement.Equals(HistoricCurrentAccountMapper.Description.Withdraw.Key) ? HistoricCurrentAccountMapper.Description.Withdraw.Description
                : src.Movement.Equals(HistoricCurrentAccountMapper.Description.Yield.Key) ? HistoricCurrentAccountMapper.Description.Yield.Description
                : src.Movement;
            });
        }
    }
}
