using MediatR;
using WebAPI_Test.Model;

namespace WebAPI_Test.Commands
{
    public record AddVehicleCommand(string VIN, string LicenseNumber, string RegistrationPlate, DateTime LicenseExpiry, string Model, string Color, int AccountID) : IRequest<Vehicle>;
}
