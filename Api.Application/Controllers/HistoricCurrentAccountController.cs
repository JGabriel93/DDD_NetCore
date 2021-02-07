using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos.Transaction;
using Api.Domain.Interfaces.Services.CurrentAccount;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricCurrentAccountController : ControllerBase
    {
        private IHistoricCurrentAccountService _service;
        public HistoricCurrentAccountController(IHistoricCurrentAccountService service)
        {
            _service = service;
        }

        //[Authorize("Bearer")]
        [HttpGet]
        [Route("{userId}")]
        public async Task<ActionResult> Get(Guid userId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                //var userId = new Guid(User.Identity.Name);
                return Ok(await _service.FindByUserId(userId));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
