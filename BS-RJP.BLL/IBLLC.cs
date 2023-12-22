using BS_RJP.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS_RJP.BLL
{
    public interface IBLLC
    {
        int _CurrentUserId { get; set; }
        Task<LoginResponse> Login(ParamsLogin param);
        Task SubmitAccountAsync(Account param);
        Task SubmitTransactionAsync(Transaction param);
        Task<Customer> GetCustomerByIdAdvancedAsync(ParamsGetCustomerByIdAdvancedAsync param);
    }
}
