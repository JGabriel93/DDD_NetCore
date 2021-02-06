using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.CurrentAccount;
using Api.Domain.Dtos.Transaction;
using Api.Domain.Entities.CurrentAccount;
using Api.Domain.Interfaces.Services.CurrentAccount;
using Api.Domain.Repository;
using AutoMapper;

namespace Api.Service.Services
{
    public class CurrentAccountService : ICurrentAccountService
    {
        private ICurrentAccountRepository _repository;
        private IUserRepository _repositoryUser;
        private IHistoricCurrentAccountRepository _repositoryHistoricCurrentAccount;
        private readonly IMapper _mapper;

        public CurrentAccountService(ICurrentAccountRepository repository,
                                    IUserRepository repositoryUser,
                                    IHistoricCurrentAccountRepository repositoryHistoricCurrentAccount,
                                    IMapper mapper)
        {
            _repository = repository;
            _repositoryUser = repositoryUser;
            _repositoryHistoricCurrentAccount = repositoryHistoricCurrentAccount;
            _mapper = mapper;
        }

        public async Task<CurrentAccountDtoResult> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<CurrentAccountDtoResult>(entity);
        }

        public async Task<CurrentAccountEntity> FindByUserId(Guid userId)
        {
            return await _repository.FindByUserId(userId);
        }

        public async Task<Guid> Insert(CurrentAccountEntity entity)
        {
            return await _repository.InsertAsync(entity);
        }

        public async Task<CurrentAccountDtoResult> UpdateDeposit(DepositDto depositDto, Guid userId)
        {
            var entity = await FindByUserId(userId);
            entity.Balance += depositDto.Value;

            var result = await _repository.UpdateAsync(entity, entity.Id);
            await InsertHistory("D", depositDto.Value, entity.Id);

            return _mapper.Map<CurrentAccountDtoResult>(result);
        }

        public async Task<CurrentAccountDtoResult> UpdatePayment(PaymentDto paymentDto, Guid userId)
        {
            var entity = await FindByUserId(userId);
            ValidateBalance(entity.Balance, paymentDto.Value);

            entity.Balance -= paymentDto.Value;

            var result = await _repository.UpdateAsync(entity, entity.Id);
            await InsertHistory("P", paymentDto.Value, entity.Id);

            return _mapper.Map<CurrentAccountDtoResult>(result);
        }

        public async Task<CurrentAccountDtoResult> UpdateTransfer(TransferDto transferDto, Guid userId)
        {
            var entity = await FindByUserId(userId);
            ValidateBalance(entity.Balance, transferDto.Value);

            var entityUserRecipient = await _repositoryUser.FindByCpf(transferDto.CpfRecipient);
            var entityRecipient = await _repository.FindByUserId(entityUserRecipient.Id);

            entityRecipient.Balance += transferDto.Value;
            entity.Balance -= transferDto.Value;

            var result = await _repository.UpdateAsync(entity, entity.Id);
            await _repository.UpdateAsync(entityRecipient, entityRecipient.Id);

            await InsertHistory("T", transferDto.Value, entity.Id);
            await InsertHistory("D", transferDto.Value, entityRecipient.Id);

            return _mapper.Map<CurrentAccountDtoResult>(result);
        }

        public async Task<CurrentAccountDtoResult> UpdateWithdraw(WithdrawDto withdrawDto, Guid userId)
        {
            var entity = await FindByUserId(userId);
            ValidateBalance(entity.Balance, withdrawDto.Value);

            entity.Balance -= withdrawDto.Value;

            var result = await _repository.UpdateAsync(entity, entity.Id);
            await InsertHistory("W", withdrawDto.Value, entity.Id);

            return _mapper.Map<CurrentAccountDtoResult>(result);
        }

        public async Task<bool> ApplyIncome()
        {
            try
            {
                var listAccounts = await _repository.SelectAllAsync();
                var yield = Convert.ToDecimal(Environment.GetEnvironmentVariable("YIELD_VALUE"));
                var addedValue = decimal.Zero;

                foreach (var account in listAccounts)
                {
                    if (account.Balance > 0)
                    {
                        addedValue = decimal.Round(decimal.Divide(decimal.Multiply(account.Balance, yield), 100), 2);
                        account.Balance += addedValue;
                        await _repository.UpdateAsync(account, account.Id);
                        await InsertHistory("R", addedValue, account.Id);
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void ValidateBalance(decimal balance, decimal debit)
        {
            if (balance < debit)
                throw new Exception("Saldo insuficiente");
        }

        private async Task<Guid> InsertHistory(string movement, decimal amountMoved, Guid currentAccountId)
        {
            var entityHistoric = new HistoricCurrentAccountEntity
            {
                Movement = movement,
                AmountMoved = amountMoved,
                CurrentAccountId = currentAccountId
            };

            return await _repositoryHistoricCurrentAccount.InsertAsync(entityHistoric);
        }
    }
}
