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
            user.FirstName = command.FirstName;
            user.LastName = command.LastName;
            user.IDNumber = command.IDNumber;
            user.Password= command.Password;
            user.Email = command.Email;
            user.AccountId = command.AccountID;
            _context.Users.Add(user);
            //make new account with the same id number as user id (This is probably bad practice in an actual db, but since its a one and only one relationship, I'm gonna say its fine)
            var account = new Account();
            account.AccountId = user.AccountId;
            account.Balance = 0;
            account.UserId = user.AccountId;
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
