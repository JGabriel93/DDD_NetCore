using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.User
{
    public interface IUserService
    {
        Task<UserDtoResult> Get(Guid id);
        Task<IEnumerable<UserDtoResult>> Get();
        Task<Guid> Insert(UserDto entity);
        Task<UserDtoResult> Update(UserDto entity, Guid id);
        Task<bool> Delete(Guid id);
    }
}
