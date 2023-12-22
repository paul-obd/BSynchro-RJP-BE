using System;
using System.Collections.Generic;

namespace BS_RJP.EF.Models;

public partial class TblCustomer
{
    public int CustomerId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int EntryUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual TblUser EntryUser { get; set; }

    public virtual ICollection<TblAccount> TblAccounts { get; set; } = new List<TblAccount>();
}
