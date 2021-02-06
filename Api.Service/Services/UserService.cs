using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Api.Domain.Entities.CurrentAccount;
using Api.Domain.Entities.User;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Models.User;
using Api.Domain.Repository;
using AutoMapper;

namespace Api.Service.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _repository;
        private ICurrentAccountRepository _repositoryCurrentAccount;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, ICurrentAccountRepository repositoryCurrentAccount, IMapper mapper)
        {
            _repository = repository;
            _repositoryCurrentAccount = repositoryCurrentAccount;
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

            if (await _repository.ExistsByCpf(entity.Cpf))
                throw new Exception("CPF já cadastrado");

            entity.Password = BCrypt.Net.BCrypt.HashPassword(entity.Password, BCrypt.Net.BCrypt.GenerateSalt());

            var resultId = await _repository.InsertAsync(entity);
            await InsertCurrentAccount(resultId);

            return resultId;
        }

        public async Task<UserDtoResult> Update(UserDto dto, Guid id)
        {
            var model = _mapper.Map<UserModel>(dto);
            var entity = _mapper.Map<UserEntity>(model);

            entity.Password = BCrypt.Net.BCrypt.HashPassword(entity.Password, BCrypt.Net.BCrypt.GenerateSalt());

            var result = await _repository.UpdateAsync(entity, id);
            return _mapper.Map<UserDtoResult>(result);
        }

        private async Task<Guid> InsertCurrentAccount(Guid userId)
        {
            var entity = new CurrentAccountEntity
            {
                Balance = 0,
                UserId = userId
            };

            return await _repositoryCurrentAccount.InsertAsync(entity);
        }
    }
}
