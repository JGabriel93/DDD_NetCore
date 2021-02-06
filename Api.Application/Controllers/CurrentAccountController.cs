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
    public class CurrentAccountController : ControllerBase
    {
        private ICurrentAccountService _service;
        public CurrentAccountController(ICurrentAccountService service)
        {
            _service = service;
        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(await _service.Get(id));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPut]
        [Route("deposit")]
        public async Task<ActionResult> UpdateDeposit([FromBody] DepositDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var userId = new Guid(User.Identity.Name);
                var result = await _service.UpdateDeposit(dto, userId);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPut]
        [Route("payment")]
        public async Task<ActionResult> UpdatePayment([FromBody] PaymentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var userId = new Guid(User.Identity.Name);
                var result = await _service.UpdatePayment(dto, userId);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPut]
        [Route("transfer")]
        public async Task<ActionResult> UpdateTransfer([FromBody] TransferDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var userId = new Guid(User.Identity.Name);
                var result = await _service.UpdateTransfer(dto, userId);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPut]
        [Route("withdraw")]
        public async Task<ActionResult> UpdateWithdraw([FromBody] WithdrawDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var userId = new Guid(User.Identity.Name);
                var result = await _service.UpdateWithdraw(dto, userId);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPost]
        [Route("ApplyIncome")]
        public async Task<ActionResult> ApplyIncome()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _service.ApplyIncome();
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
