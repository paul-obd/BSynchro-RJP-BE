
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
        public delegate void PreEventHandlerSubmitAccountAsync(Account account, EnumSubmitMode enumSubmitMode);
        public delegate void PostEventHandlerSubmitAccountAsync(Account account, EnumSubmitMode enumSubmitMode);
        public event PreEventHandlerSubmitAccountAsync OnPreEventSubmitAccountAsync;
        public event PostEventHandlerSubmitAccountAsync OnPostEventSubmitAccountAsync;

        public delegate void PreEventHandlerSubmitTransactionAsync(Transaction transaction, EnumSubmitMode enumSubmitMode);
        public delegate void PostEventHandlerSubmitTransactionAsync(Transaction transaction, EnumSubmitMode enumSubmitMode);
        public event PreEventHandlerSubmitTransactionAsync OnPreEventSubmitTransactionAsync;
        public event PostEventHandlerSubmitTransactionAsync OnPostEventSubmitTransactionAsync;


        public void SubscribeToEvents()
        {
            //here I subscribe to my events
        }

        #region <Entity> Events Handlers

        #endregion


    }


}
