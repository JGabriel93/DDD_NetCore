using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.User
{
    public class GetAllTest : UserTest
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "Mantida a integridade do método para obter todos os usuários")]
        public async Task TestGet()
        {
            const int NUMBER_USERS = 5;

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Get()).ReturnsAsync(listUserDtoResult);
            _service = _serviceMock.Object;

            var result = await _service.Get();
            Assert.NotNull(result);
            Assert.True(result.Count() == NUMBER_USERS);

            var listResult = new List<UserDtoResult>();

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Get()).ReturnsAsync(listResult.AsEnumerable);
            _service = _serviceMock.Object;

            var resultEmpty = await _service.Get();
            Assert.Empty(resultEmpty);
        }
    }
}
