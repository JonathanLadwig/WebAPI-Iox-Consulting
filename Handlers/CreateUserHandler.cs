using MediatR;
using Microsoft.Extensions.Configuration.UserSecrets;
using WebAPI_Test.Commands;
using WebAPI_Test.Model;

namespace WebAPI_Test.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IoxDbContext _context;
        public CreateUserHandler(IoxDbContext context)
        {
            _context = context; 
        }
        public async Task<int> Handle(CreateUserCommand command, CancellationToken cancellationToken) 
        {
            var user = new User();
            user.FirstName = command.FirstName;
            user.LastName = command.LastName;
            user.Idnumber = command.IDNumber;
            user.Password= command.Password;
            user.Email = command.Email; 
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user.UserId;
            //TODO: Create new account as part of this handler and add the account ID to the statement
        }

        Task<User> IRequestHandler<CreateUserCommand, User>.Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
