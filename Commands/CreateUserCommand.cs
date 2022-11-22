using MediatR;
using WebAPI_Test.Model;

namespace WebAPI_Test.Commands
{
    public class CreateUserCommand : IRequest<User>
    {
        public string UserID { get; set; }  
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int IDNumber { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int AccountId { get; set; }

        public CreateUserCommand()
        {

        }
    }
}
