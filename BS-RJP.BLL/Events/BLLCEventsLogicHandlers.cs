using BS_RJP.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS_RJP.BLL
{
    //here I put all the logical handlers (all the functions where i'm applying a business rule)
    public partial class BLLC
    {
        async Task LogicHandlerPostSubmitTransactionUpdateAccountBalance(Transaction transaction, EnumSubmitMode enumSubmitMode)
        {
            if (enumSubmitMode == EnumSubmitMode.Add)
            {
                if (transaction != null && transaction.TransactionId > 0 && transaction.AccountId > 0 && transaction.Amount > 0)
                {
                    ParamsGetAccountByIdAsync oParamsGetAccountByIdAsync = new ParamsGetAccountByIdAsync()
                    {
                        AccountId = transaction.AccountId,
                    };
                    var oAccount = await GetAccountByIdAsync(oParamsGetAccountByIdAsync).ConfigureAwait(false); ;
                    if(oAccount != null)
                    {
                        oAccount.Balance += transaction.Amount;
                        await SubmitAccountAsync(oAccount).ConfigureAwait(false);
                    }
                }
            }
        }
    }
}
