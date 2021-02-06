using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.CurrentAccount;
using Api.Domain.Entities.CurrentAccount;
using Api.Domain.Interfaces.Services.CurrentAccount;
using Api.Domain.Repository;
using AutoMapper;

namespace Api.Service.Services
{
    public class HistoricCurrentAccountService : IHistoricCurrentAccountService
    {
        private IHistoricCurrentAccountRepository _repository;
        private ICurrentAccountRepository _repositoryCurrentAccount;
        private readonly IMapper _mapper;

        public HistoricCurrentAccountService(IHistoricCurrentAccountRepository repository, ICurrentAccountRepository repositoryCurrentAccount, IMapper mapper)
        {
            _repository = repository;
            _repositoryCurrentAccount = repositoryCurrentAccount;
            _mapper = mapper;
        }

        public async Task<IEnumerable<HistoricCurrentAccountDtoResult>> FindByUserId(Guid userId)
        {
            var currentAccount = await new CurrentAccountService(_repositoryCurrentAccount, null, _repository, _mapper).FindByUserId(userId);
            var entity = await _repository.FindByCurrentAccountId(currentAccount.Id);
            return _mapper.Map<IEnumerable<HistoricCurrentAccountDtoResult>>(entity);
        }

        public async Task<Guid> Insert(HistoricCurrentAccountEntity entity)
        {
            return await _repository.InsertAsync(entity);
        }

        private async Task<IEnumerable<HistoricCurrentAccountDtoResult>> FindByCurrentAccountId(Guid currentAccountId)
        {
            var entity = await _repository.FindByCurrentAccountId(currentAccountId);
            return _mapper.Map<IEnumerable<HistoricCurrentAccountDtoResult>>(entity);
        }
    }
}
