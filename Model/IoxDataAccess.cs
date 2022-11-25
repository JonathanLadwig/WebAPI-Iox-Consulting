namespace WebAPI_Test.Model
{
    public interface IoxDataAccess
    {
        List<Account> GetAccounts();
        List<User> GetUsers();
        List<Vehicle> GetVehicles();
        Account InsertAccount(int accountId, decimal balance, int userId);
        User InsertUser(int userId, string firstName, string lastName, string iDNumber, string password, string email, int accountId);
        Vehicle InsertVehicle(int vehicleId, string vin, string licenseNumber, string registrationPlate, DateOnly licenseExpiry, string model, string color, int accountId);
    }
}