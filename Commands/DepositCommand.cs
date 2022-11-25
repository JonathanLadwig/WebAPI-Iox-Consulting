using MediatR;
using WebAPI_Test.Model;

namespace WebAPI_Test.Commands
{
    public record DepositCommand(int AccountID, decimal Balance) : IRequest<Account>;
}
