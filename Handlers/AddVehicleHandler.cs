using MediatR;
using WebAPI_Test.Commands;
using WebAPI_Test.Model;

namespace WebAPI_Test.Handlers
{
    public class AddVehicleHandler : IRequestHandler<AddVehicleCommand, int>
    {
        private readonly IoxDbContext _context;
        public AddVehicleHandler(IoxDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(AddVehicleCommand command, CancellationToken cancellationToken)
        {
            var vehicle = new Vehicle();
            vehicle.Vin = command.VIN;
            vehicle.LicenseNumber = command.LicenseNumber;
            vehicle.RegistrationPlate = command.RegistrationPlate;
            vehicle.LicenseExpiry = command.LicenseExpiry;
            vehicle.Model= command.Model;
            vehicle.Color= command.Color;
            vehicle.AccountId = command.AccountID;
            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();
            return vehicle.VehicleId;
        }
    }
}
