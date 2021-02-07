using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.CurrentAccount;
using Api.Domain.Interfaces.Services.CurrentAccount;
using Moq;
using Xunit;

namespace Api.Service.Test.CurrentAccount
{
    public class GetIdTest : CurrentAccountTest
    {
        private ICurrentAccountService _service;
        private Mock<ICurrentAccountService> _serviceMock;
        private IHistoricCurrentAccountService _serviceHistoric;
        private Mock<IHistoricCurrentAccountService> _serviceMockHistoric;

        [Fact(DisplayName = "Mantida a integridade do método para obter uma conta corrente")]
        public async Task TestGet()
        {
            _serviceMock = new Mock<ICurrentAccountService>();
            _serviceMock.Setup(m => m.Get(UserId)).ReturnsAsync(currentAccountDtoResult);
            _service = _serviceMock.Object;

            var result = await _service.Get(UserId);
            Assert.NotNull(result);
            Assert.True(result.Id == Id);
            Assert.Equal(Balance, result.Balance);
            Assert.Equal(UserId, result.UserId);

            _serviceMock = new Mock<ICurrentAccountService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((CurrentAccountDtoResult)null));
            _service = _serviceMock.Object;

            var resultNull = await _service.Get(UserId);
            Assert.Null(resultNull);

            var listResult = new List<HistoricCurrentAccountDtoResult>();

            _serviceMockHistoric = new Mock<IHistoricCurrentAccountService>();
            _serviceMockHistoric.Setup(m => m.FindByUserId(UserId)).ReturnsAsync(listHistoricDtoResult);
            _serviceHistoric = _serviceMockHistoric.Object;

            var resultHistoric = await _serviceHistoric.FindByUserId(UserId);
            Assert.NotEmpty(resultHistoric);
            Assert.True(resultHistoric.Count() == 1);

            _serviceMockHistoric = new Mock<IHistoricCurrentAccountService>();
            _serviceMockHistoric.Setup(m => m.FindByUserId(It.IsAny<Guid>())).ReturnsAsync(listResult.AsEnumerable);
            _serviceHistoric = _serviceMockHistoric.Object;

            var resultHistoricEmpty = await _serviceHistoric.FindByUserId(Id);
            Assert.Empty(resultHistoricEmpty);
        }
    }
}
