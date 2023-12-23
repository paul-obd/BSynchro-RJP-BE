using AutoMapper;
using BS_RJP.DAL;
using BS_RJP.EF.Models;
using RJP.BLL;
using System.Transactions;

namespace BS_RJP.BLL
{
    public partial class BLLC : IBLLC
    {
        public int _CurrentUserId { get; set; }
        private readonly IDALC _DALC;
        private readonly IMapper _mapper;
        public BLLC(IDALC DALC, IMapper mapper)
        {
            _DALC = DALC;
            _mapper = mapper;
            SubscribeToEvents();
        }
        public async Task<LoginResponse> Login(ParamsLogin param)
        {
            var user = await _DALC.GetUserByEmailOrUsername(param.EmailOrUsername);
            LoginResponse response = new LoginResponse();
            if (user != null)
            {
                if (user.Password == param.Password)
                {
                    var Mappeduser = _mapper.Map<User>(user);
                    Mappeduser.Password = "";
                    response.User = Mappeduser;
                }
                else
                {
                    throw new BLLException("Wrong Password!");
                }
            }
            else
            {
                throw new BLLException("Email Or Username Does Not Exist!");
            }
            return response;
        }
        public async Task<Customer> GetCustomerByIdAdvancedAsync(ParamsGetCustomerByIdAdvancedAsync param)
        {
            if (param == null || param.CustomerId == null || param.CustomerId <= 0)
            {
                throw new BLLException("Invalid Customer Id!");
            }
            var preResult = await _DALC.GetCustomerByIdAdvancedAsync(param.CustomerId);
            var result = _mapper.Map<Customer>(preResult);
            return result;
        }

        public async Task SubmitAccountAsync(Account param)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    EnumSubmitMode oEditModeFlag = EnumSubmitMode.Add;
                    if (param.AccountId > 0) { oEditModeFlag = EnumSubmitMode.Update; }
                    if (_CurrentUserId != 0) { param.EntryUserId = _CurrentUserId; }

                    if (OnPreEventSubmitAccountAsync != null)
                    {
                        await OnPreEventSubmitAccountAsync(param, oEditModeFlag);
                    }

                    var mParam = _mapper.Map<TblAccount>(param);
                    var oId = await _DALC.SubmitAccountAsync(mParam);
                    param.AccountId = oId;

                    if (OnPostEventSubmitAccountAsync != null)
                    {
                        await OnPostEventSubmitAccountAsync(param, oEditModeFlag);
                    }
                    scope.Complete();
                }
                catch (Exception e)
                {
                    throw new Exception("Error while SubmitAccountAsync: " + e.Message);
                }
            }
        }

        public async Task SubmitTransactionAsync(Transaction param)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    EnumSubmitMode oEditModeFlag = EnumSubmitMode.Add;
                    if (param.TransactionId > 0) { oEditModeFlag = EnumSubmitMode.Update; }
                    if (_CurrentUserId != 0) { param.EntryUserId = _CurrentUserId; }

                    if (OnPreEventSubmitTransactionAsync != null)
                    {
                        await OnPreEventSubmitTransactionAsync(param, oEditModeFlag);
                    }

                    var mParam = _mapper.Map<TblTransaction>(param);
                    var oId = await _DALC.SubmitTransactionAsync(mParam).ConfigureAwait(false); ;
                    param.TransactionId = oId;

                    if (OnPostEventSubmitTransactionAsync != null)
                    {
                        await OnPostEventSubmitTransactionAsync(param, oEditModeFlag);
                    }

                    scope.Complete();
                }
                catch (Exception e)
                {
                    throw new Exception("Error while SubmitTransactionAsync: " + e.Message);
                }
            }
        }

        public async Task<TransactionType> GetTransactionTypeByValue(ParamsGetTransactionTypeByValue param)
        {
            if (param == null || param.Value == null)
            {
                throw new BLLException("Invalid Transaction Type value!");
            }
            var preResult = await _DALC.GetTransactionTypeByValueAsync(param.Value);
            var result = _mapper.Map<TransactionType>(preResult);
            return result;
        }

        public async Task<Account> GetAccountByIdAsync(ParamsGetAccountByIdAsync param)
        {
            if (param == null || param.AccountId == null || param.AccountId <= 0)
            {
                throw new BLLException("Invalid Account Id!");
            }
            var preResult = await _DALC.GetAccountByIdAsync(param.AccountId);
            var result = _mapper.Map<Account>(preResult);
            return result;
        }

        public async Task<List<Customer>> GetCustomersByEntryUserIdAdvancedAsync()
        {
            if (_CurrentUserId == null ||  _CurrentUserId <= 0)
            {
                throw new BLLException("Invalid Entry User Id!");
            }
            var preResult = await _DALC.GetCustomersByEntryUserIdAdvancedAsync(_CurrentUserId);
            var result = _mapper.Map<List<Customer>>(preResult);
            return result;
        }

        public async Task SubmitCustomerAsync(Customer param)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    EnumSubmitMode oEditModeFlag = EnumSubmitMode.Add;
                    if (param.CustomerId > 0) { oEditModeFlag = EnumSubmitMode.Update; }
                    if (_CurrentUserId != 0) { param.EntryUserId = _CurrentUserId; }

                    var mParam = _mapper.Map<TblCustomer>(param);
                    var oId = await _DALC.SubmitCustomerAsync(mParam).ConfigureAwait(false); ;
                    param.CustomerId = oId;

                    scope.Complete();
                }
                catch (Exception e)
                {
                    throw new Exception("Error while SubmitCustomerAsync: " + e.Message);
                }
            }
        }
    }
}