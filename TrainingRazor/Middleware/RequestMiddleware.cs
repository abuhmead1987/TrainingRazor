using TrainingRazor.ExtensionMethods;

namespace TrainingRazor.Middleware
{
    public class RequestMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _iconfig;

        public RequestMiddleware(RequestDelegate next, IConfiguration iconfig)

        {
            _next = next;
            _iconfig = iconfig;
        }
        //writ Invoke
        public async Task InvokeAsync(HttpContext context)
        {
            var request = context.Request;
            var response = context.Response;
            //the IP of the request
            var ip = context.Connection.RemoteIpAddress;
            //return 
            //the port of the request
            var port = request.Host.Port;
            //console.log
            Console.WriteLine($"Request received from {ip}:{port}");
            Console.WriteLine($"Request method: {request.Method}, TrainingAPI: {_iconfig["Hello"]}");
            Console.WriteLine($"Count of words in strings: {"Mohammad Hmedat".WordCount()}");
            await _next(context);
        }
    }
}
