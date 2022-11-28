using System;
using System.Collections.Generic;

namespace WebAPI_Test.Model;

public partial class Account
{
    public int AccountId { get; set; } //Primary Key

    public decimal Balance { get; set; }

    public int UserId { get; set; } //Foreign Key

    public virtual User User { get; set; } = null!;

    public virtual ICollection<User> Users { get; } = new List<User>();

    public virtual ICollection<Vehicle> Vehicles { get; } = new List<Vehicle>();
}
