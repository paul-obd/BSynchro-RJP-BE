using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS_RJP.BLL
{
    public class ParamsGetCustomerByIdAdvancedAsync
    {
        public int CustomerId { get; set; }
    }

    public class ParamsLogin
    {
        public string EmailOrUsername { get; set; }
        public string Password { get; set; }

    }

    public class ParamsOpenNewCurrentAccount
    {
        public int CustomerId { get; set; }
        public decimal InitialCredit { get; set; }
    }

    public class ParamsGetTransactionTypeByValue
    {
        public string Value { get; set; }
    }
    public class ParamsGetAccountByIdAsync
    {
        public int AccountId { get; set; }
    }
    
    public class ParamsGetCustomersByEntryUserId
    {
        public int EntryUserId { get; set; }
    }
}
