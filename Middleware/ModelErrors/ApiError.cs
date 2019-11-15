using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Middleware.ModelErrors
{
    public class ApiError
    {
        public string message { get; set; }
        public bool isError { get; set; }
        public string detail { get; set; }
        public string code { get; set; }
        public List<string> errors { get; set; }

        public ApiError(string message)
        {
            this.message = message;
            isError = true;
        }

        public ApiError(ModelStateDictionary modelState)
        {
            this.isError = true;
            if (modelState != null && modelState.Any(m => m.Value.Errors.Count > 0))
            {
                message = "Please correct the specified errors and try again.";
            }
        }
    }
}