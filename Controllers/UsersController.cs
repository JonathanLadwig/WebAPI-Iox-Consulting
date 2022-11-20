using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Test.Model;

namespace WebAPI_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public UsersController() { }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            IList<User> users = null;
            //string users = "userstring";
            return Ok(users);
        }
    }
}
