using System;
using System.Collections.Generic;

namespace BS_RJP.EF.Models;

public partial class TblTransaction
{
    public int TransactionId { get; set; }

    public int AccountId { get; set; }

    public decimal Amount { get; set; }

    public int TransactiontypeId { get; set; }

    public int EntryUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual TblAccount Account { get; set; }

    public virtual TblUser EntryUser { get; set; }

    public virtual TblTransactionType Transactiontype { get; set; }
}
