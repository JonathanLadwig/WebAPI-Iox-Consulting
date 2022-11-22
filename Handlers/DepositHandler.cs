using MediatR;
using WebAPI_Test.Commands;
using WebAPI_Test.Model;

namespace WebAPI_Test.Handlers
{
    public class DepositHandler : IRequestHandler<DepositCommand, Account>
    {
        private readonly IoxDbContext _context;
        public DepositHandler(IoxDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DepositCommand command, CancellationToken cancellationToken) 
        {
            Account account = _context.Accounts.Where(a => a.AccountId == command.AccountID).FirstOrDefault();
            if (account == null) 
            {
                return default;
            }
            else
            {
                account.Balance = command.Balance;
                return account.AccountId;
            }
        }

        Task<Account> IRequestHandler<DepositCommand, Account>.Handle(DepositCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
