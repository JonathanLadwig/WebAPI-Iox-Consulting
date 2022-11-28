using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Test.Commands;
using WebAPI_Test.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebAPI_Test.Handlers
{
    public class RenewLicenseHandler : IRequestHandler<RenewLicenseCommand, string>
    {
        private readonly IoxDbContext _context;
        public RenewLicenseHandler(IoxDbContext context) 
        { 
            _context= context;
        }
        public async Task<string> Handle(RenewLicenseCommand command, CancellationToken cancellationToken)
        {
            var vehicle = _context.Vehicles.Where(a => a.VehicleId == command.VehicleID).FirstOrDefault();
            Account account = _context.Accounts.Where(a => a.AccountId == vehicle.AccountId).FirstOrDefault();
            if (account.Balance < 1000)
            {
                //null gets converted into an informative error
                return "You do not have enough money left in your account";
            }
            else
            {
                vehicle.LicenseExpiry.AddYears(1);
                account.Balance -= 1000;
                await _context.SaveChangesAsync();
                return (vehicle.VehicleId + ": License extended");
            }
        }
    }
}
