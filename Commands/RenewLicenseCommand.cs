using MediatR;
using WebAPI_Test.Model;

namespace WebAPI_Test.Commands
{
    public record RenewLicenseCommand(int VehicleID) : IRequest<Vehicle>;
}
