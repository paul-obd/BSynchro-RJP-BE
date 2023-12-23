using BS_RJP.BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BS_RJP.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IBLLC _BLLC;
        private readonly IConfiguration _Configuration;

        public AuthController(IBLLC BLLC, IConfiguration Configuration)
        {
            _BLLC = BLLC;
            _Configuration = Configuration;
        }

        public async Task<APIResponseLogin> Login(ParamsLogin param)
        {
            APIResponseLogin response = new APIResponseLogin();
            try
            {
                var LoginResponse = await _BLLC.Login(param);
                LoginResponse.Token = AuthTools.CreateToken(LoginResponse.User, _Configuration);
                response.Success = true;
                response.Data = LoginResponse;
            }
            catch (Exception ex)
            {
                response.Success = false;
                if (ex.GetType().FullName != "RJP.BLL.BLLException")
                {
                    response.ErrorMessage = string.Format("Login : {0}", ex.Message);
                }
                else
                {
                    response.ErrorMessage = ex.Message;
                }
            }
            return response;
        }
    }

    public partial class ActionResult
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public ActionResult()
        {
            Success = true;
            ErrorMessage = "";
        }
    }

    public class APIResponseLogin : ActionResult
    {
        public LoginResponse Data { get; set; }
    }
}
