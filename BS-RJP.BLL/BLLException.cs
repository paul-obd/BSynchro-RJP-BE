using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJP.BLL
{
    public class BLLException : Exception
    {
        public BLLException(string MessageContent) : base(MessageContent)
        {
        }
    }
}
