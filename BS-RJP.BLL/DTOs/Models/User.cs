using System;
using System.Collections.Generic;

namespace RJP.BLL;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Phone { get; set; }

    public DateTime CreatedDate { get; set; }

    public ICollection<Account> Accounts { get; set; } = new List<Account>();

    public ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public ICollection<TransactionType> TransactionTypes { get; set; } = new List<TransactionType>();

    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
