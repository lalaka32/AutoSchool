using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Middleware.ModelErrors
{
    public class ApiError
    {
        public string message { get; set; }
        public string detail { get; set; }
        public string code { get; set; }
        public ApiError(string message)
        {
            this.message = message;
        }
    }
}