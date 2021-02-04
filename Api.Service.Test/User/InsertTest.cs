using System;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.User
{
    public class InsertTest : UserTest
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "Mantida a integridade da inserção do usuário")]
        public async Task TestInsert()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Insert(userDto)).ReturnsAsync(Id);
            _service = _serviceMock.Object;

            var resultId = await _service.Insert(userDto);
            Assert.False(resultId == Guid.Empty);
        }
    }
}
