using System;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.CurrentAccount;
using Moq;
using Xunit;

namespace Api.Service.Test.CurrentAccount
{
    public class UpdateTest : CurrentAccountTest
    {
        private ICurrentAccountService _service;
        private Mock<ICurrentAccountService> _serviceMock;

        [Fact(DisplayName = "Mantida a integridade da atualização de conta corrente")]
        public async Task TestUpdate()
        {
            _serviceMock = new Mock<ICurrentAccountService>();
            _serviceMock.Setup(m => m.Insert(entity)).ReturnsAsync(Id);
            _service = _serviceMock.Object;

            var resultId = await _service.Insert(entity);
            Assert.False(resultId == Guid.Empty);

            _serviceMock = new Mock<ICurrentAccountService>();
            _serviceMock.Setup(m => m.UpdateDeposit(depositDto, UserId)).ReturnsAsync(currentAccountDtoResultDeposit);
            _service = _serviceMock.Object;

            var resultUpdateDeposit = await _service.UpdateDeposit(depositDto, UserId);
            Assert.NotNull(resultUpdateDeposit);
            Assert.Equal(Balance + depositDto.Value, resultUpdateDeposit.Balance);
            Assert.Equal(UserId, resultUpdateDeposit.UserId);

            _serviceMock = new Mock<ICurrentAccountService>();
            _serviceMock.Setup(m => m.UpdatePayment(paymentDto, UserId)).ReturnsAsync(currentAccountDtoResultPayment);
            _service = _serviceMock.Object;

            var resultUpdatePayment = await _service.UpdatePayment(paymentDto, UserId);
            Assert.NotNull(resultUpdatePayment);
            Assert.Equal(Balance - paymentDto.Value, resultUpdatePayment.Balance);
            Assert.Equal(UserId, resultUpdatePayment.UserId);

            _serviceMock = new Mock<ICurrentAccountService>();
            _serviceMock.Setup(m => m.UpdateTransfer(transferDto, UserId)).ReturnsAsync(currentAccountDtoResultTransfer);
            _service = _serviceMock.Object;

            var resultUpdateTransfer = await _service.UpdateTransfer(transferDto, UserId);
            Assert.NotNull(resultUpdatePayment);
            Assert.Equal(Balance - transferDto.Value, resultUpdateTransfer.Balance);
            Assert.Equal(UserId, resultUpdateTransfer.UserId);

            _serviceMock = new Mock<ICurrentAccountService>();
            _serviceMock.Setup(m => m.UpdateWithdraw(withdrawDto, UserId)).ReturnsAsync(currentAccountDtoResultWithdraw);
            _service = _serviceMock.Object;

            var resultUpdateWithdraw = await _service.UpdateWithdraw(withdrawDto, UserId);
            Assert.NotNull(resultUpdatePayment);
            Assert.Equal(Balance - withdrawDto.Value, resultUpdateWithdraw.Balance);
            Assert.Equal(UserId, resultUpdateWithdraw.UserId);
        }
    }
}
