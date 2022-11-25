using System;
using System.Collections.Generic;

namespace WebAPI_Test.Model;

public partial class User
{
    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string IDNumber { get; set; }

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int AccountId { get; set; }

    public User(int userId, string firstName, string lastName, string iDNumber, string password, string email, int accountId)
    {
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
        IDNumber = iDNumber;
        Password = password;
        Email = email;
        AccountId = accountId;
    }



    //public virtual Account Account { get; set; }// = null!;

    //public virtual ICollection<Account> Accounts { get; } = new List<Account>();
}
