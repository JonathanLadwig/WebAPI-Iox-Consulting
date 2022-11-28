using MessagePack;
using System;
using System.Collections.Generic;

namespace WebAPI_Test.Model;

public partial class User
{
    public int UserId { get; set; } // Primary key

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string IDNumber { get; set; }

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int AccountId { get; set; } //Foreign key

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<Account> Accounts { get; } = new List<Account>();

    public User()
    {

    }
}
