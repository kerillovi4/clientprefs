using clientprefs.Config;
using Microsoft.EntityFrameworkCore;

namespace clientprefs.Database
{
    //Add-Migration init -Context NpgsqlContext -OutputDir Migrations/NpgsqlMigrations

    public class NpgsqlContext : DatabaseContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string query;

#if DEBUG
            query = "Server = localhost; Port = 5432; User Id = clientprefs; Password = clientprefs; Database = clientprefs";
#else
            AppSettings appSettings = AppSettings.Instance;

            query = string.Format("Server = {0}; Port = {1}; User Id = {2}; Password = {3}; Database = {4}",  appSettings.host, appSettings.port, appSettings.user, appSettings.pass, appSettings.database);
#endif

            optionsBuilder.UseNpgsql(query);
        }
    }
}