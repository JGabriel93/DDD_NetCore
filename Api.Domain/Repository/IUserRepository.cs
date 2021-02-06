using System.Threading.Tasks;
using Api.Domain.Entities.User;
using Api.Domain.Interfaces;

namespace Api.Domain.Repository
{
    public interface IUserRepository : IBaseRepository<UserEntity>
    {
        Task<UserEntity> FindByEmail(string email);
        Task<UserEntity> FindByCpf(string cpf);
        Task<bool> ExistsByCpf(string cpf);
    }
}
