using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.User.Create
{
    public class ResultInsertBadRequestTest
    {
        private UsersController _controller;

        [Fact(DisplayName = "Mantida a integridade da inserção do usuário")]
        public async Task TestInsert()
        {
            const string VALID_CPF = "12345678909";
            const string VALID_PASSWORD = "teste123";
            const string URL = "http://localhost:5000";

            var name = Faker.Name.FullName();
            var email = Faker.Internet.Email();
            var cpf = VALID_CPF;
            var password = BCrypt.Net.BCrypt.HashPassword(VALID_PASSWORD, BCrypt.Net.BCrypt.GenerateSalt());

            var serviceMock = new Mock<IUserService>();
            serviceMock.Setup(m => m.Insert(It.IsAny<UserDto>())).ReturnsAsync(It.IsAny<Guid>());
            _controller = new UsersController(serviceMock.Object);
            _controller.ModelState.AddModelError("Nome", "Nome é obrigatório");

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

            var result = await _controller.Insert(userDto);
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }
    }
}
