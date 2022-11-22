using MediatR;
using WebAPI_Test.Commands;
using WebAPI_Test.Model;

namespace WebAPI_Test.Handlers
{
    public class AddVehicleHandler : IRequestHandler<AddVehicleCommand, Vehicle>
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
            //TODO: Make new account with balance 0 and return the accountID Value
            //vehicle.AccountId = command.AccountID;
            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();
            return vehicle.VehicleId;
        }

        Task<Vehicle> IRequestHandler<AddVehicleCommand, Vehicle>.Handle(AddVehicleCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
