using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.CurrentAccount;
using Api.Domain.Dtos.Transaction;
using Api.Domain.Entities.CurrentAccount;

namespace Api.Domain.Interfaces.Services.CurrentAccount
{
    public interface ICurrentAccountService
    {
        Task<CurrentAccountDtoResult> Get(Guid id);
        Task<Guid> Insert(CurrentAccountEntity entity);
        Task<CurrentAccountDtoResult> UpdateDeposit(DepositDto depositDto, Guid userId);
        Task<CurrentAccountDtoResult> UpdatePayment(PaymentDto paymentDto, Guid userId);
        Task<CurrentAccountDtoResult> UpdateTransfer(TransferDto transferDto, Guid userId);
        Task<CurrentAccountDtoResult> UpdateWithdraw(WithdrawDto withdrawDto, Guid userId);
    }
}
