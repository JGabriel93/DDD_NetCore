using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.User.Update
{
    public class ResultUpdateTest
    {
        private UsersController _controller;

        [Fact(DisplayName = "Mantida a integridade da atualização do usuário")]
        public async Task TestUpdate()
        {
            const string VALID_CPF = "12345678909";
            const string VALID_PASSWORD = "teste123";
            const string URL = "http://localhost:5000";

            var id = Guid.NewGuid();
            var name = Faker.Name.FullName();
            var email = Faker.Internet.Email();
            var cpf = VALID_CPF;
            var password = BCrypt.Net.BCrypt.HashPassword(VALID_PASSWORD, BCrypt.Net.BCrypt.GenerateSalt());

            var serviceMock = new Mock<IUserService>();
            serviceMock.Setup(m => m.Update(It.IsAny<UserDto>(), It.IsAny<Guid>())).ReturnsAsync(new UserDtoResult
            {
                Id = id,
                Name = name,
                Email = email,
                Cpf = cpf
            });
            _controller = new UsersController(serviceMock.Object);

            var url = new Mock<IUrlHelper>();
            url.Setup(m => m.Link(It.IsAny<string>(), It.IsAny<object>())).Returns(URL);
            _controller.Url = url.Object;

            var userDto = new UserDto
            {
                Name = name,
                Email = email,
                Cpf = cpf,
                Password = password
            };

            var result = await _controller.Update(userDto, id);
            Assert.True(result is OkObjectResult);
        }
    }
}
