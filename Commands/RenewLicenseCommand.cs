using MediatR;
using WebAPI_Test.Model;

namespace WebAPI_Test.Commands
{
    public record RenewLicenseCommand(int VehicleID, DateOnly LicenseExpiry, int AccountID, decimal Balance) : IRequest<Vehicle>;
}
