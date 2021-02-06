using System;
using System.Collections.Generic;
using Api.Domain.Dtos.CurrentAccount;
using Api.Domain.Dtos.Transaction;
using Api.Domain.Entities.CurrentAccount;

namespace Api.Service.Test.CurrentAccount
{
    public class CurrentAccountTest
    {
        public Guid Id { get; set; }
        public decimal Balance { get; set; }
        public Guid UserId { get; set; }
        public string Movement { get; set; }
        public decimal AmountMoved { get; set; }
        public Guid HistoricCurrentAccountId { get; set; }

        public CurrentAccountEntity entity = new CurrentAccountEntity();
        public HistoricCurrentAccountEntity entityHistoric = new HistoricCurrentAccountEntity();
        public CurrentAccountDtoResult currentAccountDtoResult = new CurrentAccountDtoResult();
        public HistoricCurrentAccountDtoResult historicCurrentAccountDtoResult = new HistoricCurrentAccountDtoResult();
        public List<HistoricCurrentAccountDtoResult> listHistoricDtoResult = new List<HistoricCurrentAccountDtoResult>();
        public CurrentAccountDtoResult currentAccountDtoResultDeposit = new CurrentAccountDtoResult();
        public CurrentAccountDtoResult currentAccountDtoResultPayment = new CurrentAccountDtoResult();
        public CurrentAccountDtoResult currentAccountDtoResultTransfer = new CurrentAccountDtoResult();
        public CurrentAccountDtoResult currentAccountDtoResultWithdraw = new CurrentAccountDtoResult();

        public DepositDto depositDto = new DepositDto();
        public PaymentDto paymentDto = new PaymentDto();
        public TransferDto transferDto = new TransferDto();
        public WithdrawDto withdrawDto = new WithdrawDto();

        public CurrentAccountTest()
        {
            Id = Guid.NewGuid();
            Balance = 1000;
            UserId = new Guid("3362d96b-e3ff-4cc8-85b5-da08a612e62f");

            HistoricCurrentAccountId = Guid.NewGuid();
            Movement = "D";
            AmountMoved = Balance;

            entity = new CurrentAccountEntity()
            {
                Id = Id,
                Balance = 1000,
                UserId = UserId
            };

            entityHistoric = new HistoricCurrentAccountEntity()
            {
                Id = Guid.NewGuid(),
                Movement = Movement,
                AmountMoved = AmountMoved,
                CurrentAccountId = Id
            };

            currentAccountDtoResult = new CurrentAccountDtoResult()
            {
                Id = Id,
                Balance = Balance,
                UserId = UserId
            };

            historicCurrentAccountDtoResult = new HistoricCurrentAccountDtoResult()
            {
                Id = HistoricCurrentAccountId,
                Movement = Movement,
                AmountMoved = AmountMoved,
                CurrentAccountId = Id
            };

            listHistoricDtoResult.Add(historicCurrentAccountDtoResult);

            depositDto = new DepositDto { Value = 500 };
            paymentDto = new PaymentDto { Value = 300 };
            transferDto = new TransferDto { Value = 400, CpfRecipient = "26687020544" };
            withdrawDto = new WithdrawDto { Value = 200 };

            currentAccountDtoResultDeposit = new CurrentAccountDtoResult()
            {
                Id = Id,
                Balance = Balance + depositDto.Value,
                UserId = UserId
            };

            currentAccountDtoResultPayment = new CurrentAccountDtoResult()
            {
                Id = Id,
                Balance = Balance - paymentDto.Value,
                UserId = UserId
            };

            currentAccountDtoResultTransfer = new CurrentAccountDtoResult()
            {
                Id = Id,
                Balance = Balance - transferDto.Value,
                UserId = UserId
            };

            currentAccountDtoResultWithdraw = new CurrentAccountDtoResult()
            {
                Id = Id,
                Balance = Balance - withdrawDto.Value,
                UserId = UserId
            };
        }
    }
}
