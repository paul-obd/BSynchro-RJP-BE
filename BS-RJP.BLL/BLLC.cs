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
                        OnPreEventSubmitAccountAsync(param, oEditModeFlag);
                    }

                    var mParam = _mapper.Map<TblAccount>(param);
                    var oId = await _DALC.SubmitAccountAsync(mParam);
                    param.CustomerId = oId;

                    if (OnPostEventSubmitAccountAsync != null)
                    {
                        OnPostEventSubmitAccountAsync(param, oEditModeFlag);
                    }
                }
                catch (Exception e)
                {
                    throw new BLLException("Error while SubmitAccountAsync: " + e.Message);
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
                    if (param.TransactionId > 0){oEditModeFlag = EnumSubmitMode.Update;}
                    if (_CurrentUserId != 0) { param.EntryUserId = _CurrentUserId; }

                    if (OnPreEventSubmitTransactionAsync != null)
                    {
                        OnPreEventSubmitTransactionAsync(param, oEditModeFlag);
                    }

                    var mParam = _mapper.Map<TblTransaction>(param);
                    var oId = await _DALC.SubmitTransactionAsync(mParam);
                    param.TransactionId = oId;

                    if (OnPostEventSubmitTransactionAsync != null)
                    {
                        OnPostEventSubmitTransactionAsync(param, oEditModeFlag);
                    }
                }
                catch (Exception e)
                {
                    throw new BLLException("Error while SubmitTransactionAsync: " + e.Message);
                }
            }
        }
    }
}