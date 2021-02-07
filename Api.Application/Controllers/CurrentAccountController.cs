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

        //[Authorize("Bearer")]
        [HttpGet]
        [Route("{userId}")]
        public async Task<ActionResult> Get(Guid userId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(await _service.Get(userId));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        //[Authorize("Bearer")]
        [HttpPut]
        [Route("deposit/{userId}")]
        public async Task<ActionResult> Deposit([FromBody] DepositDto dto, Guid userId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                //var userId = new Guid(User.Identity.Name);
                var result = await _service.UpdateDeposit(dto, userId);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        //[Authorize("Bearer")]
        [HttpPut]
        [Route("payment/{userId}")]
        public async Task<ActionResult> Payment([FromBody] PaymentDto dto, Guid userId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                //var userId = new Guid(User.Identity.Name);
                var result = await _service.UpdatePayment(dto, userId);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        //[Authorize("Bearer")]
        [HttpPut]
        [Route("transfer/{userId}")]
        public async Task<ActionResult> Transfer([FromBody] TransferDto dto, Guid userId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                //var userId = new Guid(User.Identity.Name);
                var result = await _service.UpdateTransfer(dto, userId);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        //[Authorize("Bearer")]
        [HttpPut]
        [Route("withdraw/{userId}")]
        public async Task<ActionResult> Withdraw([FromBody] WithdrawDto dto, Guid userId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                //var userId = new Guid(User.Identity.Name);
                var result = await _service.UpdateWithdraw(dto, userId);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        //[Authorize("Bearer")]
        [HttpPost]
        [Route("applyincome")]
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
