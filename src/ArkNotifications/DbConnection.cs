using ArkNotifications.Models;
using Microsoft.EntityFrameworkCore;

namespace ArkNotifications
{
    public class DbConnection : DbContext
    {
        public DbConnection(DbContextOptions<DbConnection> options)
            : base(options)
        { }

        public DbSet<NotificationModel> Notifications { get; set; }
        public DbSet<ApiKeysModel> ApiKeys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
