using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.User
{
    public interface IUserService
    {
        Task<UserEntity> Get(Guid id);
        Task<IEnumerable<UserEntity>> Get();
        Task<Guid> Insert(UserEntity entity);
        Task<UserEntity> Update(UserEntity entity);
        Task<bool> Delete(Guid id);
    }
}
