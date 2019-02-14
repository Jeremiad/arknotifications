using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using Serilog;
using Microsoft.Extensions.DependencyInjection;

namespace ArkNotifications
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            var host = CreateWebHostBuilder(args).Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                try
                {
                    var dbContext = services.GetRequiredService<DbConnection>();
                    dbContext.Database.EnsureCreated();
                }
                catch (System.Exception ex)
                {
                    Log.Fatal(ex.Message);
                }
            }
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseUrls("http://+:8080")
            .UseStartup<Startup>();
    }
}

