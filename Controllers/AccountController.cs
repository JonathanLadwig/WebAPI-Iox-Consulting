using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Test.Commands;
using WebAPI_Test.Model;

namespace WebAPI_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        //Deposit: increase the balance by the amount passed in
        [HttpPut("{AccountID}")]
        public async Task<IActionResult> Deposit(int accountID, DepositCommand command)
        {
            if (accountID != command.AccountID) {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
    }
}
