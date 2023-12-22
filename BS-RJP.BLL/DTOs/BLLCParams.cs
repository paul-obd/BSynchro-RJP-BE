using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS_RJP.BLL
{
    public class ParamsGetCustomerByIdAdvancedAsync
    {
        public int CustomerId { get; set; }
    }

    public class ParamsLogin
    {
        public string EmailOrUsername { get; set; }
        public string Password { get; set; }

    }
}
