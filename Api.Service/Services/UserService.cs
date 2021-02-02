using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Api.Domain.Entities.User;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Models.User;
using AutoMapper;

namespace Api.Service.Services
{
    public class UserService : IUserService
    {
        private IRepository<UserEntity> _repository;
        private readonly IMapper _mapper;

        public UserService(IRepository<UserEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<UserDtoResult> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<UserDtoResult>(entity);
        }

        public async Task<IEnumerable<UserDtoResult>> Get()
        {
            var listEntity = await _repository.SelectAllAsync();
            return _mapper.Map<IEnumerable<UserDtoResult>>(listEntity);
        }

        public async Task<Guid> Insert(UserDto dto)
        {
            var model = _mapper.Map<UserModel>(dto);
            var entity = _mapper.Map<UserEntity>(model);

            entity.Password = BCrypt.Net.BCrypt.HashPassword(entity.Password, BCrypt.Net.BCrypt.GenerateSalt());

            return await _repository.InsertAsync(entity);
        }

        public async Task<UserDtoResult> Update(UserDto dto, Guid id)
        {
            var model = _mapper.Map<UserModel>(dto);
            var entity = _mapper.Map<UserEntity>(model);

            entity.Password = BCrypt.Net.BCrypt.HashPassword(entity.Password, BCrypt.Net.BCrypt.GenerateSalt());

            var result = await _repository.UpdateAsync(entity, id);
            return _mapper.Map<UserDtoResult>(result);
        }
    }
}
