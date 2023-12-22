using System;
using System.Collections.Generic;

namespace BS_RJP.EF.Models;

public partial class TblUser
{
    public int UserId { get; set; }

    public string Username { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Phone { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual ICollection<TblAccount> TblAccounts { get; set; } = new List<TblAccount>();

    public virtual ICollection<TblCustomer> TblCustomers { get; set; } = new List<TblCustomer>();

    public virtual ICollection<TblTransactionType> TblTransactionTypes { get; set; } = new List<TblTransactionType>();

    public virtual ICollection<TblTransaction> TblTransactions { get; set; } = new List<TblTransaction>();
}
