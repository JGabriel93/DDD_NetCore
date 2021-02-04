using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.User.Delete
{
    public class ResultDeleteBadRequestTest
    {
        private UsersController _controller;

        [Fact(DisplayName = "Mantida a integridade da deleção do usuário")]
        public async Task TestDelete()
        {
            var serviceMock = new Mock<IUserService>();
            serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _controller = new UsersController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Id inválido");

            var result = await _controller.Delete(default(Guid));
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }
    }
}
