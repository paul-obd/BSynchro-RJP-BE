
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS_RJP.BLL
{
    //Here I put all the handlers where I Cascade insert, update or delete 
    public partial class BLLC
    {

        #region Accounts & Transactions

        async Task CascadeOpenNewCurrentAccountTransactions(ParamsOpenNewCurrentAccount param, Account Account)
        {
            if (param != null && param.InitialCredit > 0 && Account.AccountId > 0)
            {
                ParamsGetTransactionTypeByValue oParamsGetTransactionTypeByValue = new ParamsGetTransactionTypeByValue()
                {
                    Value = "credit"
                };
                var TransactionType = await GetTransactionTypeByValue(oParamsGetTransactionTypeByValue).ConfigureAwait(false); ;

                var o = new Transaction()
                {
                    AccountId = Account.AccountId,
                    Amount = param.InitialCredit,
                    TransactiontypeId = TransactionType.TransactiontypeId,
                    EntryUserId = _CurrentUserId
                };
                await SubmitTransactionAsync(o).ConfigureAwait(false); ;
            }
        }

        #endregion
    }
}
