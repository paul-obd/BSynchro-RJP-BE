﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS_RJP.BLL
{
    public class LoginResponse
    {
        public User User { get; set; }
        public string Token { get; set; }
    }

}
