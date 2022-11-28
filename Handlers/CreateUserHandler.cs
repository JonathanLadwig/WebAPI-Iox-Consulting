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
        public async Task<User> Handle(CreateUserCommand command, CancellationToken cancellationToken) 
        {
            User user = new User();
            Account account = new Account();
            user.FirstName = command.FirstName;
            user.LastName = command.LastName;
            user.IDNumber = command.IDNumber;
            user.Password= command.Password;
            user.Email = command.Email;
            user.AccountId = account.AccountId; 
            account.Balance = 0;
            account.UserId = user.UserId;
            //Need to create a new account get that account id to finish making the user, then get the user id to finish making account.
            _context.Users.Add(user); 
            _context.Accounts.Add(account); 
            await _context.SaveChanges(); 
            return user;
        }
    }
}
