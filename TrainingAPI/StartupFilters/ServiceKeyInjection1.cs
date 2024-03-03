
[assembly: HostingStartup(typeof(TrainingAPI.StartupFilters.ServiceKeyInjection1))]
namespace TrainingAPI.StartupFilters
{
    public class ServiceKeyInjection1 : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            Console.WriteLine("ServiceKeyInjection: Configure");
            builder.ConfigureAppConfiguration(config =>
            {                
                var dict = new Dictionary<string, string>
                {
                    {"DevAccount_FromLibrary", "DEV_1111111-1111"},
                    {"ProdAccount_FromLibrary", "PROD_2222222-2222"}
                };

                config.AddInMemoryCollection(dict);
            });
        }
    }
}
