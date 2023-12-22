using System;
using System.Collections.Generic;

namespace RJP.BLL;

public partial class Account
{
    public int AccountId { get; set; }

    public int CustomerId { get; set; }

    public decimal Balance { get; set; }

    public int EntryUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public Customer Customer { get; set; } = null!;

    public User EntryUser { get; set; } = null!;

    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
