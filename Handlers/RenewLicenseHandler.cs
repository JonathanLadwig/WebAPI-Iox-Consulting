using MediatR;
using WebAPI_Test.Commands;
using WebAPI_Test.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebAPI_Test.Handlers
{
    public class RenewLicenseHandler : IRequestHandler<RenewLicenseCommand, Vehicle>
    {
        private readonly IoxDataAccess _context; //IoxDbContext
        public RenewLicenseHandler(IoxDataAccess context) //IoxDbContext
        { 
            _context= context;
        }
        public async Task<Vehicle> Handle(RenewLicenseCommand command, CancellationToken cancellationToken)
        {
            Vehicle vehicle = _context.GetVehicles.Where(a => a.Vehicle);    
            //Vehicle vehicle = _context.Vehicles.Where(a => a.VehicleId == command.VehicleID).FirstOrDefault();
            if (vehicle == null) 
            {
                return null;
            }
            Account account = _context.Accounts.Where(a => a.AccountId == vehicle.AccountId).FirstOrDefault();   
            if (account.Balance <= 1000) {
                //return error
                return null;
            }
            vehicle.LicenseExpiry = command.LicenseExpiry.AddYears(1);  
            return vehicle;
        }
    }
}
