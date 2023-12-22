using BS_RJP.EF.Models;
using RJP.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BS_RJP.BLL
{
    public partial class BLLC
    {
        public async Task OpenNewCurrentAccount(ParamsOpenNewCurrentAccount param)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    if (OnPreEventOpenNewCurrentAccount != null)
                    {
                       await OnPreEventOpenNewCurrentAccount(param);
                    }

                    Account o = new Account()
                    {
                        CustomerId = param.CustomerId,
                        Balance = 0,
                        EntryUserId = _CurrentUserId
                    };
                    await SubmitAccountAsync(o);

                    if (OnPostEventOpenNewCurrentAccount != null)
                    {
                        await OnPostEventOpenNewCurrentAccount(param, o.AccountId);
                    }

                    scope.Complete();
                }
                catch (Exception e)
                {
                    throw new BLLException("Error while OpenNewCurrentAccount: " + e.Message);
                }
            }
        }
    }
}
