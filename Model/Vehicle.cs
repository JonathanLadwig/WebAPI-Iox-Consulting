using System;
using System.Collections.Generic;

namespace WebAPI_Test.Model;

public partial class Vehicle
{
    public int VehicleId { get; set; }

    public int Vin { get; set; }

    public int LicenseNumber { get; set; }

    public string RegistrationPlate { get; set; } = null!;

    public DateTime LicenseExpiry { get; set; }

    public string Model { get; set; } = null!;

    public string Color { get; set; } = null!;

    public int AccountId { get; set; }

    public virtual Account Account { get; set; } = null!;
}
