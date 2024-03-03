using Microsoft.AspNetCore.Hosting;
using TrainingAPI.MiddleWares;

namespace TrainingAPI.StartupFilters
{
    public class ConsoleStartupFilter : IStartupFilter
    {

        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            try
            {
                
                return builder =>
                {
                    builder.UseMiddleware<MyLoggerMiddleware>();
                    next(builder);
                };
            }
            catch (Exception)
            {

                throw new NotImplementedException(); 
            }
            
        }
    }
}
