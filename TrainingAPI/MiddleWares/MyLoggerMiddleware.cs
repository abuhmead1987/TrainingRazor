using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace TrainingAPI.MiddleWares
{
    public class MyLoggerMiddleware 
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public MyLoggerMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration= configuration;            
        }

        // Test with https://localhost:5001/Privacy/?option=Hello
        public async Task Invoke(HttpContext httpContext)
        {            
            await Console.Out.WriteLineAsync($"Hello From My MiddleWare In {httpContext.Request.Path}");
            Console.WriteLine($"Read configuration from configuration file from MyLoggerMiddleware, Database Configuration is: {_configuration["Database"]}");
            Console.WriteLine($"Read configuration from configuration file from MyLoggerMiddleware, DevAccount_FromPackage Configuration is: {_configuration["DevAccount_FromPackage"]}");
            var option = httpContext.Request.Query["option"];

            //if (!string.IsNullOrWhiteSpace(option))
            //{
            //    httpContext.Items["option"] = WebUtility.HtmlEncode(option);
            //}            
            await _next(httpContext);
            await Console.Out.WriteLineAsync($"Hello From My MiddleWare Out, options: {option.ToString()}");
        }
    }
}