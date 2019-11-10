using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Ecxeptions
{
    public class BadOperationException : Exception
    {
        public BadOperationException(ErrorCode code)
        {
            Code = code;
        }

        public ErrorCode Code { get; set; }
    }
}
