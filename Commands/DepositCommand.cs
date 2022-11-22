using MediatR;
using WebAPI_Test.Model;

namespace WebAPI_Test.Commands
{
    public class DepositCommand : IRequest<Account>
    {
        public int AccountID { get; set; }
        public decimal Balance { get; set; }
        public int UserID { get; set; }
    }
}
