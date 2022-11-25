using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Test.Model;

namespace WebAPI_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        //Creates a new user with the details sent
        [HttpPost]  
        public async Task<IActionResult> CreateUser(Commands.CreateUserCommand command) 
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
