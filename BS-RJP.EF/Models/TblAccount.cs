using System;
using System.Collections.Generic;

namespace BS_RJP.EF.Models;

public partial class TblAccount
{
    public int AccountId { get; set; }

    public int CustomerId { get; set; }

    public decimal Balance { get; set; }

    public int EntryUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual TblCustomer Customer { get; set; }

    public virtual TblUser EntryUser { get; set; }

    public virtual ICollection<TblTransaction> TblTransactions { get; set; } = new List<TblTransaction>();
}
