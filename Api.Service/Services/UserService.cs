using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.User;

namespace Api.Service.Services
{
    public class UserService : IUserService
    {
        private IRepository<UserEntity> _repository;

        public UserService(IRepository<UserEntity> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<UserEntity> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<UserEntity>> Get()
        {
            return await _repository.SelectAllAsync();
        }

        public async Task<Guid> Insert(UserEntity entity)
        {
            return await _repository.InsertAsync(entity);
        }

        public async Task<UserEntity> Update(UserEntity entity)
        {
            return await _repository.UpdateAsync(entity);
        }
    }
}
