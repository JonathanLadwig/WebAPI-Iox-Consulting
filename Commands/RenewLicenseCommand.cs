using MediatR;
using WebAPI_Test.Model;

namespace WebAPI_Test.Commands
{
    public class RenewLicenseCommand : IRequest<Vehicle>
    {
        public int VehicleID { get; set; }
        public DateOnly LicenseExpiry { get; set; }

        public int AccountID { get; set; }
        public int Balance { get; set; }
    }
}
