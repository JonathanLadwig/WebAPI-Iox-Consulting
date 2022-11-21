using MediatR;

namespace WebAPI_Test.Commands
{
    public class AddVehicleCommand : IRequest<int>
    {
        public int VIN { get; set; }
        public int LicenseNumber { get; set; }
        public string RegistrationPlate { get; set;}
        public DateOnly LicenseExpiry { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
         
        public int AccountID { get; set; } 

    }
}
