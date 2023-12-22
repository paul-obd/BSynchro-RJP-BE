using System;
using System.Collections.Generic;

namespace RJP.BLL;

public partial class TransactionType
{
    public int TransactiontypeId { get; set; }

    public string Value { get; set; } = null!;

    public int EntryUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public User EntryUser { get; set; } = null!;

    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
