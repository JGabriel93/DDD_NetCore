using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.User.Get
{
    public class ResultGetTestBadRequestTest
    {
        private UsersController _controller;

        [Fact(DisplayName = "Mantida a integridade do método para obter todos os usuários")]
        public async Task TestGet()
        {
            var serviceMock = new Mock<IUserService>();
            serviceMock.Setup(m => m.Get()).ReturnsAsync(
                new List<UserDtoResult>
                {
                    new UserDtoResult
                    {
                        Id = Guid.NewGuid(),
                        Name =  Faker.Name.FullName(),
                        Email = Faker.Internet.Email(),
                        Cpf = "12345678909"
                    },
                    new UserDtoResult
                    {
                        Id = Guid.NewGuid(),
                        Name =  Faker.Name.FullName(),
                        Email = Faker.Internet.Email(),
                        Cpf = "21154974065"
                    }
                });

            _controller = new UsersController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Id inválido");

            var result = await _controller.GetAll();
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
