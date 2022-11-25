using System;
using System.Collections.Generic;

namespace WebAPI_Test.Model;

public partial class Vehicle
{
    public int VehicleId { get; set; }

    public string Vin { get; set; }

    public string LicenseNumber { get; set; }

    public string RegistrationPlate { get; set; } = null!;

    public DateOnly LicenseExpiry { get; set; }

    public string Model { get; set; } = null!;

    public string Color { get; set; } = null!;

    public int AccountId { get; set; }

   // public virtual Account Account { get; set; } = null!;

    public Vehicle(int vehicleId, string vin, string licenseNumber, string registrationPlate, DateOnly licenseExpiry, string model, string color, int accountId)
    {
        VehicleId = vehicleId;
        Vin = vin;
        LicenseNumber = licenseNumber;
        RegistrationPlate = registrationPlate;
        LicenseExpiry = licenseExpiry;
        Model = model;
        Color = color;
        AccountId = accountId;
    }

    //public Vehicle()
    //{
    //}
}
