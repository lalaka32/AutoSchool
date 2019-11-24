using System;
using System.Linq;
using System.Threading.Tasks;
using Common.Authorization;
using Common.Ecxeptions;
using Common.ModelErrors;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Middleware.MiddleWare
{
    public class HandleExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public HandleExceptionMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                var corsHeaders = context.Response.Headers.Where(x => x.Key.Contains("Access-Control")).ToList();
                if (context.Response.HasStarted)
                {
                    throw;
                }

                context.Response.Clear();
                foreach (var corsHeader in corsHeaders)
                {
                    context.Response.Headers[corsHeader.Key] = corsHeader.Value;
                }

                ApiError apiError = null;
                if (exception is ForbiddenException)
                {
                    apiError = new ApiError("You are not authorized for this operation");
                    context.Response.StatusCode = 403;
                }
                else if (exception is UnauthorizedAccessException)
                {
                    apiError = new ApiError("Unauthorized Access");
                    context.Response.StatusCode = 401;

                    // handle logging here
                }
                else if (exception is BadOperationException)
                {
                    var errorCode = (exception as BadOperationException).Code;

                    apiError = new ApiError("Error occured") {code = errorCode.Value};

                    context.Response.StatusCode = errorCode == ErrorCode.NotFound
                        ? 404
                        : 400;
                }
                else
                {
                    // Unhandled errors
                    var msg = exception.GetBaseException().Message;
                    var stack = exception.StackTrace;

                    apiError = new ApiError(msg) {detail = stack};

                    context.Response.StatusCode = 500;

                    // handle logging here
                }

                // always return a JSON result


                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(JsonConvert.SerializeObject(apiError));
            }
        }
    }
}