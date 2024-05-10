using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.OTo.Core.Exceptions
{
    public class ValidateException:Exception
    {
        string? MsgErrorValidate=null;
        public ValidateException(string msg) 
        {
            this.MsgErrorValidate = msg;
        }

        public override string Message
        {
            get { return this.MsgErrorValidate; }
        }
    }
}
