using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_Test.Model;

public partial class IoxDbContext : DbContext
{
    public IoxDbContext()
    {
    }
    //new line added
    public async Task<int> SaveChanges()
    {
        return await base.SaveChangesAsync();
    }

    public IoxDbContext(DbContextOptions<IoxDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }
    public object Issues { get; internal set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\Local;Initial Catalog=\"IOX DB\";Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.ToTable("ACCOUNT");

            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.Balance).HasColumnType("money");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ACCOUNT_USER");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("USER");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IDNumber).HasColumnName("IDNumber");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(25)
                .IsUnicode(false);

            entity.HasOne(d => d.Account).WithMany(p => p.Users)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_USER_ACCOUNT");
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.ToTable("VEHICLE");

            entity.Property(e => e.VehicleId).HasColumnName("VehicleID");
            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.Color)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.LicenseExpiry).HasColumnType("date");
            entity.Property(e => e.Model)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationPlate)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Vin).HasColumnName("VIN");

            entity.HasOne(d => d.Account).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VEHICLE_ACCOUNT");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
