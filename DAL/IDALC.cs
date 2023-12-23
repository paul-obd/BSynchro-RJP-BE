using BS_RJP.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS_RJP.DAL
{
    public interface IDALC
    {
        Task<TblUser> GetUserByEmailOrUsername(string ParamEmailOrUsername);
        Task<int> SubmitAccountAsync(TblAccount param);
        Task<int> SubmitTransactionAsync(TblTransaction param);
        Task<int> SubmitCustomerAsync(TblCustomer param);
        Task<TblCustomer> GetCustomerByIdAdvancedAsync(int CustomerId);
        Task<TblTransactionType> GetTransactionTypeByValueAsync(string value);
        Task<TblAccount> GetAccountByIdAsync(int AccountId);

        Task<List<TblCustomer>> GetCustomersByEntryUserIdAdvancedAsync(int EntryUserId);
    }
}
