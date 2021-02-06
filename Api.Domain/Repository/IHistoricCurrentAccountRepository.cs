using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities.CurrentAccount;
using Api.Domain.Interfaces;

namespace Api.Domain.Repository
{
    public interface IHistoricCurrentAccountRepository : IBaseRepository<HistoricCurrentAccountEntity>
    {
        Task<IEnumerable<HistoricCurrentAccountEntity>> FindByCurrentAccountId(Guid currentAccountId);
    }
}
