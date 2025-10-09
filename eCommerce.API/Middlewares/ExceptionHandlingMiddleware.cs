using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace eCommerce.API.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next,
            ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            { 
                await _next(httpContext); 
            }
            catch(Exception e)
            {
                // log the exception type and message
                _logger.LogError($"{e.GetType().ToString()} : {e.Message}");

                if (e.InnerException is not null)
                {
                    _logger.LogError($"{e.InnerException.GetType()}:{e.InnerException.Message}");
                }

                httpContext.Response.StatusCode = 500; // internal server error 
                await httpContext.Response.WriteAsJsonAsync(new { Messaage = e.Message, Type
                = e.GetType().ToString() });

            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
