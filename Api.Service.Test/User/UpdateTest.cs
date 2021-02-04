using System;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.User
{
    public class UpdateTest : UserTest
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "Mantida a integridade da atualização do usuário")]
        public async Task TestUpdate()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Insert(userDto)).ReturnsAsync(Id);
            _service = _serviceMock.Object;

            var resultId = await _service.Insert(userDto);
            Assert.False(resultId == Guid.Empty);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Update(userDtoUpdate, resultId)).ReturnsAsync(userDtoResultUpdate);
            _service = _serviceMock.Object;

            var resultUpdate = await _service.Update(userDtoUpdate, resultId);
            Assert.NotNull(resultUpdate);
            Assert.Equal(ChangedName, resultUpdate.Name);
            Assert.Equal(ChangedEmail, resultUpdate.Email);
            Assert.Equal(ChangedCpf, resultUpdate.Cpf);
        }
    }
}
