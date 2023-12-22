using System;
using System.Collections.Generic;

namespace RJP.BLL;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public int AccountId { get; set; }

    public decimal Amount { get; set; }

    public int TransactiontypeId { get; set; }

    public int EntryUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public Account Account { get; set; } = null!;

    public User EntryUser { get; set; } = null!;

    public TransactionType Transactiontype { get; set; } = null!;
}
