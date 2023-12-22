
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS_RJP.BLL
{
    public partial class BLLC
    {

        //Here I declare all of my delegates and events
        public delegate Task PreEventHandlerSubmitAccountAsync(Account account, EnumSubmitMode enumSubmitMode);
        public delegate Task PostEventHandlerSubmitAccountAsync(Account account, EnumSubmitMode enumSubmitMode);
        public event PreEventHandlerSubmitAccountAsync OnPreEventSubmitAccountAsync;
        public event PostEventHandlerSubmitAccountAsync OnPostEventSubmitAccountAsync;

        public delegate Task PreEventHandlerSubmitTransactionAsync(Transaction transaction, EnumSubmitMode enumSubmitMode);
        public delegate Task PostEventHandlerSubmitTransactionAsync(Transaction transaction, EnumSubmitMode enumSubmitMode);
        public event PreEventHandlerSubmitTransactionAsync OnPreEventSubmitTransactionAsync;
        public event PostEventHandlerSubmitTransactionAsync OnPostEventSubmitTransactionAsync;

        public delegate Task PreEventHandlerOpenNewCurrentAccount(ParamsOpenNewCurrentAccount param);
        public delegate Task PostEventHandlerOpenNewCurrentAccount(ParamsOpenNewCurrentAccount param, int AccountId);
        public event PreEventHandlerOpenNewCurrentAccount OnPreEventOpenNewCurrentAccount;
        public event PostEventHandlerOpenNewCurrentAccount OnPostEventOpenNewCurrentAccount;


        public void SubscribeToEvents()
        {
            //here I subscribe to my events
            SubscribeOpenNewCurrentAccountEventsHandlers();
            SubscribeSubmitTransactionEventsHandlers();
        }

        #region Accounts & Transactions Events Handlers
        public void SubscribeOpenNewCurrentAccountEventsHandlers()
        {
            OnPostEventOpenNewCurrentAccount += CascadeOpenNewCurrentAccountTransactions;
        }

        public void SubscribeSubmitTransactionEventsHandlers()
        {
            OnPostEventSubmitTransactionAsync += LogicHandlerPostSubmitTransactionUpdateAccountBalance;
        }

        #endregion


    }


}
