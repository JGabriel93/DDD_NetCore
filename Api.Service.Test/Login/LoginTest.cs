using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.Login;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.Login
{
    public class LoginTest
    {
        private ILoginService _service;
        private Mock<ILoginService> _serviceMock;

        [Fact(DisplayName = "Mantida a integridade do login")]
        public async Task TestLogin()
        {
            const string VALID_PASSWORD = "teste123";

            var email = Faker.Internet.Email();
            var password = BCrypt.Net.BCrypt.HashPassword(VALID_PASSWORD, BCrypt.Net.BCrypt.GenerateSalt());

            var result = new
            {
                authenticated = true,
                created = DateTime.UtcNow,
                expiration = DateTime.UtcNow.AddMinutes(10),
                acessToken = Guid.NewGuid(),
                userName = email,
                message = "Login realizado com sucesso"
            };

            var dto = new LoginDto
            {
                Email = email,
                Password = password
            };

            _serviceMock = new Mock<ILoginService>();
            _serviceMock.Setup(m => m.FindBy(dto)).ReturnsAsync(result);
            _service = _serviceMock.Object;

            var resultLogin = await _service.FindBy(dto);
            Assert.NotNull(resultLogin);
        }
    }
}
