using System;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.CurrentAccount;
using Moq;
using Xunit;

namespace Api.Service.Test.CurrentAccount
{
    public class InsertTest : CurrentAccountTest
    {
        private ICurrentAccountService _service;
        private Mock<ICurrentAccountService> _serviceMock;
        private IHistoricCurrentAccountService _serviceHistoric;
        private Mock<IHistoricCurrentAccountService> _serviceMockHistoric;

        [Fact(DisplayName = "Mantida a integridade da inserção da conta")]
        public async Task TestInsert()
        {
            _serviceMock = new Mock<ICurrentAccountService>();
            _serviceMock.Setup(m => m.Insert(entity)).ReturnsAsync(Id);
            _service = _serviceMock.Object;

            var resultId = await _service.Insert(entity);
            Assert.False(resultId == Guid.Empty);

            _serviceMockHistoric = new Mock<IHistoricCurrentAccountService>();
            _serviceMockHistoric.Setup(m => m.Insert(entityHistoric)).ReturnsAsync(HistoricCurrentAccountId);
            _serviceHistoric = _serviceMockHistoric.Object;

            var historicResultId = await _serviceHistoric.Insert(entityHistoric);
            Assert.False(historicResultId == Guid.Empty);
        }
    }
}
