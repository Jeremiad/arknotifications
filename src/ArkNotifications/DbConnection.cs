using ArkNotifications.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ArkNotifications
{
    public class DbConnection : DbContext
    {
        public DbSet<NotificationModel> Notifications { get; set; }
        public DbSet<ApiKeysModel> ApiKeys { get; set; }
        private static IConfigurationRoot Configuration { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            optionsBuilder.UseSqlServer(Configuration["Database:MSSQL:ConnectionString"]);
        }
    }
}
