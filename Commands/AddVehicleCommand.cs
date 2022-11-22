using MediatR;
using WebAPI_Test.Model;

namespace WebAPI_Test.Commands
{
    public record AddVehicleCommand(int VIN, int LicenseNumber, string RegistrationPlate, DateOnly LicenseExpiry, string Model, string Color) : IRequest<Vehicle>;
    //public class AddVehicleCommand : IRequest<Vehicle>
    //{
    //    public int VehicleId { get; set; }  
    //    public int VIN { get; set; }
    //    public int LicenseNumber { get; set; }
    //    public string RegistrationPlate { get; set;}
    //    public DateOnly LicenseExpiry { get; set; }
    //    public string Model { get; set; }
    //    public string Color { get; set; }

    //    public int AccountID { get; set; }

    //    public AddVehicleCommand()
    //    {

    //    }
    //}
}
