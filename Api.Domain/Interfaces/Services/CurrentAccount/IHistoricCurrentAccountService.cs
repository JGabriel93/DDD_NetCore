using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.CurrentAccount;
using Api.Domain.Entities.CurrentAccount;

namespace Api.Domain.Interfaces.Services.CurrentAccount
{
    public interface IHistoricCurrentAccountService
    {
        Task<Guid> Insert(HistoricCurrentAccountEntity entity);
        Task<IEnumerable<HistoricCurrentAccountDtoResult>> FindByUserId(Guid userId);
    }
}
