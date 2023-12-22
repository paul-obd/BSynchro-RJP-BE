using BS_RJP.BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BS_RJP.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IBLLC _BLLC;
        public DataController(IBLLC BLLC)
        {
            _BLLC = BLLC;
        }

        [HttpPost]
        public async Task<APIResponseOpenNewCurrentAccount> OpenNewCurrentAccount(ParamsOpenNewCurrentAccount param)
        {
            APIResponseOpenNewCurrentAccount response = new APIResponseOpenNewCurrentAccount();
            try
            {
                AuthTools.ResolveToken(Request.HttpContext, _BLLC);
                await _BLLC.OpenNewCurrentAccount(param);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                if (ex.GetType().FullName != "BS-RJP.BLL.BLLException")
                {
                    response.ErrorMessage = string.Format("OpenNewCurrentAccount : {0}", ex.Message);
                }
                else
                {
                    response.ErrorMessage = ex.Message;
                }

            }
            return response;
        }

        [HttpPost]
        public async Task<APIResponseSubmitCustomerAsync> SubmitCustomerAsync(Customer param)
        {
            APIResponseSubmitCustomerAsync response = new APIResponseSubmitCustomerAsync();
            try
            {
                AuthTools.ResolveToken(Request.HttpContext, _BLLC);
                await _BLLC.SubmitCustomerAsync(param);
                response.Success = true;
                response.Data = param;
            }
            catch (Exception ex)
            {
                response.Success = false;
                if (ex.GetType().FullName != "BS-RJP.BLL.BLLException")
                {
                    response.ErrorMessage = string.Format("SubmitCustomerAsync : {0}", ex.Message);
                }
                else
                {
                    response.ErrorMessage = ex.Message;
                }

            }
            return response;
        }

        [HttpGet]
        public async Task<APIResponseGetCustomersByEntryUserIdAdvancedAsync> GetCustomersByEntryUserIdAdvancedAsync()
        {
            APIResponseGetCustomersByEntryUserIdAdvancedAsync response = new APIResponseGetCustomersByEntryUserIdAdvancedAsync();
            try
            {
                AuthTools.ResolveToken(Request.HttpContext, _BLLC);
                response.Data =  await _BLLC.GetCustomersByEntryUserIdAdvancedAsync();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                if (ex.GetType().FullName != "BS-RJP.BLL.BLLException")
                {
                    response.ErrorMessage = string.Format("GetCustomersByEntryUserIdAdvancedAsync : {0}", ex.Message);
                }
                else
                {
                    response.ErrorMessage = ex.Message;
                }

            }
            return response;
        }

        [HttpPost]
        public async Task<APIResponseGetCustomerByIdAdvancedAsync> GetCustomerByIdAdvancedAsync(ParamsGetCustomerByIdAdvancedAsync param)
        {
            APIResponseGetCustomerByIdAdvancedAsync response = new APIResponseGetCustomerByIdAdvancedAsync();
            try
            {
                AuthTools.ResolveToken(Request.HttpContext, _BLLC);
                response.Data = await _BLLC.GetCustomerByIdAdvancedAsync(param);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                if (ex.GetType().FullName != "BS-RJP.BLL.BLLException")
                {
                    response.ErrorMessage = string.Format("GetCustomerByIdAdvancedAsync : {0}", ex.Message);
                }
                else
                {
                    response.ErrorMessage = ex.Message;
                }

            }
            return response;
        }
    }

    public class APIResponseOpenNewCurrentAccount :ActionResult
    {

    }
    public class APIResponseSubmitCustomerAsync : ActionResult
    {
        public Customer Data { get; set; }
    }
    
    public class APIResponseGetCustomersByEntryUserIdAdvancedAsync : ActionResult
    {
        public List<Customer> Data { get; set; }
    }
    
    public class APIResponseGetCustomerByIdAdvancedAsync : ActionResult
    {
        public Customer Data { get; set; }
    }
}
