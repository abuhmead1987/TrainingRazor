using TrainingAPI.StartupFilters;

namespace TrainingAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ////Here you can add the configuration file by creating a new object of configuration builder and build it 

            //var config = new ConfigurationBuilder()
            //       .AddJsonFile("appsettings.json", optional: false)
            //       .Build();

            var builder = WebApplication.CreateBuilder(args);

            //Or you can add the configuration file to current builder

            builder.Configuration.AddJsonFile("appsettings.json");

            //Here how to read all the configurations loaded by the system at runtime 
            foreach (var c in builder.Configuration.AsEnumerable())
            {
                Console.WriteLine(c.Key + " = " + c.Value);
            }
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();




            //Transient lifetime services are created each time they are requested. This lifetime works best for lightweight, stateless services, such as an ORM.
            //Scoped lifetime services are created once per request, and then disposed of as soon as the request is finished, or when the application is shut down.
            //Singleton lifetime services are created once and never disposed. This lifetime works best for lightweight, stateless services

            builder.Services.AddTransient<IStartupFilter, ConsoleStartupFilter>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //If the application called  over http it redicrect to https
            app.UseHttpsRedirection();

            app.UseAuthorization();

            //It maps the controllers with their names 
            app.MapControllers();

            app.Run();
        }
    }
}
