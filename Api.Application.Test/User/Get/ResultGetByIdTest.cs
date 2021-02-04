using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.User.Get
{
    public class ResultGetByIdTest
    {
        private UsersController _controller;

        [Fact(DisplayName = "Mantida a integridade do método para obter um único usuário")]
        public async Task TestGetById()
        {
            const string VALID_CPF = "12345678909";

            var name = Faker.Name.FullName();
            var email = Faker.Internet.Email();
            var cpf = VALID_CPF;

            var serviceMock = new Mock<IUserService>();
            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
                new UserDtoResult
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Email = email,
                    Cpf = cpf
                });

            _controller = new UsersController(serviceMock.Object);

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

            var resultValue = ((ObjectResult)result).Value as UserDtoResult;
            Assert.NotNull(resultValue);
            Assert.Equal(name, resultValue.Name);
            Assert.Equal(email, resultValue.Email);
            Assert.Equal(cpf, resultValue.Cpf);
        }
    }
}
