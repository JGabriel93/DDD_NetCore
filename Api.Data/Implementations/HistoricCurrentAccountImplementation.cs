using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities.CurrentAccount;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class HistoricCurrentAccountImplementation : BaseRepository<HistoricCurrentAccountEntity>, IHistoricCurrentAccountRepository
    {
        private DbSet<HistoricCurrentAccountEntity> _dataset;

        public HistoricCurrentAccountImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<HistoricCurrentAccountEntity>();
        }

        public async Task<IEnumerable<HistoricCurrentAccountEntity>> FindByCurrentAccountId(Guid currentAccountId)
        {
            return await _dataset.Where(h => h.CurrentAccountId.Equals(currentAccountId)).OrderByDescending(h => h.CreateAt).ToListAsync();
        }
    }
}
