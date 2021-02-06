using System;
using System.Threading.Tasks;
using Api.Domain.Entities.CurrentAccount;
using Api.Domain.Interfaces;

namespace Api.Domain.Repository
{
    public interface ICurrentAccountRepository : IBaseRepository<CurrentAccountEntity>
    {
        Task<CurrentAccountEntity> FindByUserId(Guid userId);
    }
}
