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
            var user = new User();
            var account = new Account();
            user.FirstName = command.FirstName;
            user.LastName = command.LastName;
            user.IDNumber = command.IDNumber;
            user.Password= command.Password;
            user.Email = command.Email;
            //Make new account with balance 0 and return the accountID Value
            account.Balance = 0;
            _context.Users.Add(user);
            //gets userID and saves it in accounts, then adds account to the db
            account.UserId = account.AccountId;
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            return user;
            //TODO: Create new account as part of this handler and add the account ID to the statement
        }
    }
}
