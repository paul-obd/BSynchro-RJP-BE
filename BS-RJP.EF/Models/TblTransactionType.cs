using System;
using System.Collections.Generic;

namespace BS_RJP.EF.Models;

public partial class TblTransactionType
{
    public int TransactiontypeId { get; set; }

    public string Value { get; set; }

    public int EntryUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual TblUser EntryUser { get; set; }

    public virtual ICollection<TblTransaction> TblTransactions { get; set; } = new List<TblTransaction>();
}
