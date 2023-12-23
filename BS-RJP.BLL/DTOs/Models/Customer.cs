using System;
using System.Collections.Generic;

namespace BS_RJP.BLL;
public partial class Customer
{
    public int CustomerId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int EntryUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public User EntryUser { get; set; } = null!;

    public ICollection<Account> Accounts { get; set; } = new List<Account>();
}
