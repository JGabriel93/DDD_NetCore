using System;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities.CurrentAccount;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class CurrentAccountImplementation : BaseRepository<CurrentAccountEntity>, ICurrentAccountRepository
    {
        private DbSet<CurrentAccountEntity> _dataset;

        public CurrentAccountImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<CurrentAccountEntity>();
        }

        public async Task<CurrentAccountEntity> FindByUserId(Guid userId)
        {
            var result = await _dataset.FirstOrDefaultAsync(u => u.UserId.Equals(userId));

            if (result == null)
                throw new Exception("Usuário não encontrado");

            return result;
        }
    }
}
