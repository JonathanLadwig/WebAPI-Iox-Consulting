using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_Test.Model;


// public partial class if using real database and add : DbContext
public class IoxDbContext : IoxDataAccess
// : DbContext
{
    private List<Vehicle> vehicles = new List<Vehicle>();
    private List<User> users = new List<User>();
    private List<Account> accounts = new List<Account>();
    public IoxDbContext()
    {
        DateOnly date = new DateOnly(2023, 1, 1);
        vehicles.Add(new Vehicle(1, "J1V", "J1L", "JON1", date, "VW Golf", "White", 1));
        vehicles.Add(new Vehicle(2, "J2V", "J2L", "JON2", date, "BMW M3", "Blue", 1));
        users.Add(new User(1, "Jon", "Lad", "980401", "ILuvCode", "jonlad98@gmail.com", 1));
        accounts.Add(new Account(1, 0, 1));
    }

    public List<Vehicle> GetVehicles()
    {
        return vehicles;
    }
    public List<User> GetUsers()
    {
        return users;
    }
    public List<Account> GetAccounts()
    {
        return accounts;
    }

    public Vehicle InsertVehicle(int vehicleId, string vin, string licenseNumber, string registrationPlate, DateOnly licenseExpiry, string model, string color, int accountId)
    {
        Vehicle v = new Vehicle(vehicleId, vin, licenseNumber, registrationPlate, licenseExpiry, model, color, accountId);
        vehicles.Add(v);
        return v;
    }

    public User InsertUser(int userId, string firstName, string lastName, string iDNumber, string password, string email, int accountId)
    {
        User u = new User(userId, firstName, lastName, iDNumber, password, email, accountId);
        users.Add(u);
        return u;
    }

    public Account InsertAccount(int accountId, decimal balance, int userId)
    {
        Account a = new Account(accountId, balance, userId);
        return a;
    }
}
    //new line added
//    public async Task<int> SaveChanges()
//    {
//        return await base.SaveChangesAsync();
//    }

//    public IoxDbContext(DbContextOptions<IoxDbContext> options)
//        : base(options)
//    {
//    }

//    public virtual DbSet<Account> Accounts { get; set; }

//    public virtual DbSet<User> Users { get; set; }

//    public virtual DbSet<Vehicle> Vehicles { get; set; }
//    public object Issues { get; internal set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\Local;Initial Catalog=\"IOX DB\";Integrated Security=True");

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<Account>(entity =>
//        {
//            entity.ToTable("ACCOUNT");

//            entity.Property(e => e.AccountId).HasColumnName("AccountID");
//            entity.Property(e => e.Balance).HasColumnType("money");
//            entity.Property(e => e.UserId).HasColumnName("UserID");

//            entity.HasOne(d => d.User).WithMany(p => p.Accounts)
//                .HasForeignKey(d => d.UserId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_ACCOUNT_USER");
//        });

//        modelBuilder.Entity<User>(entity =>
//        {
//            entity.ToTable("USER");

//            entity.Property(e => e.UserId).HasColumnName("UserID");
//            entity.Property(e => e.AccountId).HasColumnName("AccountID");
//            entity.Property(e => e.Email)
//                .HasMaxLength(50)
//                .IsUnicode(false);
//            entity.Property(e => e.FirstName)
//                .HasMaxLength(50)
//                .IsUnicode(false);
//            entity.Property(e => e.IDNumber).HasColumnName("IDNumber");
//            entity.Property(e => e.LastName)
//                .HasMaxLength(50)
//                .IsUnicode(false);
//            entity.Property(e => e.Password)
//                .HasMaxLength(25)
//                .IsUnicode(false);

//            entity.HasOne(d => d.Account).WithMany(p => p.Users)
//                .HasForeignKey(d => d.AccountId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_USER_ACCOUNT");
//        });

//        modelBuilder.Entity<Vehicle>(entity =>
//        {
//            entity.ToTable("VEHICLE");

//            entity.Property(e => e.VehicleId).HasColumnName("VehicleID");
//            entity.Property(e => e.AccountId).HasColumnName("AccountID");
//            entity.Property(e => e.Color)
//                .HasMaxLength(25)
//                .IsUnicode(false);
//            entity.Property(e => e.LicenseExpiry).HasColumnType("date");
//            entity.Property(e => e.Model)
//                .HasMaxLength(50)
//                .IsUnicode(false);
//            entity.Property(e => e.RegistrationPlate)
//                .HasMaxLength(50)
//                .IsUnicode(false);
//            entity.Property(e => e.Vin).HasColumnName("VIN");

//            entity.HasOne(d => d.Account).WithMany(p => p.Vehicles)
//                .HasForeignKey(d => d.AccountId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_VEHICLE_ACCOUNT");
//        });

//        OnModelCreatingPartial(modelBuilder);
//    }

//    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//}
