using MediatR;
using WebAPI_Test.Model;

namespace WebAPI_Test.Commands
{
    public record CreateUserCommand(string FirstName, string LastName, string IDNumber, string Password, string Email, int AccountID) : IRequest<User>;
}
