
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS_RJP.BLL
{
    //Here I put all the handlers where I Cascade insert, update or delete (If after adding a product i wanna add it's flavors in Product_Flavors table)
    public partial class BLLC
    {

        #region Accounts & Transactions

        async Task CascadeOpenNewCurrentAccountTransactions(ParamsOpenNewCurrentAccount param, int AccountId)
        {
            if (param != null && param.InitialCredit > 0 && AccountId > 0)
            {
                ParamsGetTransactionTypeByValue oParamsGetTransactionTypeByValue = new ParamsGetTransactionTypeByValue()
                {
                    Value = "credit"
                };
                var TransactionType = await GetTransactionTypeByValue(oParamsGetTransactionTypeByValue);

                var o = new Transaction()
                {
                    AccountId = AccountId,
                    Amount = param.InitialCredit,
                    TransactiontypeId = TransactionType.TransactiontypeId,
                    EntryUserId = _CurrentUserId
                };
                await SubmitTransactionAsync(o);
            }
        }

        #endregion
    }
}
