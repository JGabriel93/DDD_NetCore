using System;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities.User;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class UserImplementation : BaseRepository<UserEntity>, IUserRepository
    {
        private DbSet<UserEntity> _dataset;

        public UserImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<UserEntity>();
        }

        public async Task<UserEntity> FindByCpf(string cpf)
        {
            var result = await _dataset.FirstOrDefaultAsync(u => u.Cpf.Equals(cpf));

            if (result == null)
                throw new FormatException("CPF não encontrado");

            return result;
        }

        public async Task<UserEntity> FindByEmail(string email)
        {
            return await _dataset.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }

        public async Task<bool> ExistsByCpf(string cpf)
        {
            return await _dataset.AnyAsync(u => u.Cpf.Equals(cpf));
        }
    }
}
