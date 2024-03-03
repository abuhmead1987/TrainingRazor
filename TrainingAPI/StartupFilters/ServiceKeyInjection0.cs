using Microsoft.Extensions.Configuration;

[assembly: HostingStartup(typeof(TrainingAPI.StartupFilters.ServiceKeyInjection0))]
namespace TrainingAPI.StartupFilters
{
    public class ServiceKeyInjection0 : IHostingStartup
    {

        public void Configure(IWebHostBuilder builder)
        {
            Console.WriteLine("ServiceKeyInjection2: Configure");
            builder.ConfigureAppConfiguration(config =>
            {
                config.AddJsonFile("extra_appsettings.json");
                var dict = new Dictionary<string, string>
                {
                    {"DevAccount_FromPackage", "DEV_3333333-3333"},
                    {"ProdAccount_FromPackage", "PROD_4444444-4444"}
                };

                config.AddInMemoryCollection(dict);
            });
        }
    }
}
