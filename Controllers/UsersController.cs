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

        private readonly IoxDbContext _context;

        public UsersController(IoxDbContext context) => _context = context;

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            IList<User> users = null;
            //string users = "userstring";
            return Ok(users);
        }

        [HttpPost]  
        public async Task<IActionResult> CreateUser(Commands.CreateUserCommand command) 
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
