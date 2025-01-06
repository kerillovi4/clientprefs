using clientprefs.Config;
using Microsoft.EntityFrameworkCore;

namespace clientprefs.Database
{
    //Add-Migration init -Context MySQLContext -OutputDir Migrations/MySQLMigrations

    public class MySQLContext : DatabaseContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string query;

#if DEBUG
            query = "server = localhost; port = 3306; user = localhost; password = localhost; database = localhost;";
#else
            AppSettings appSettings = AppSettings.Instance;

            query = string.Format("server = {0}; port = {1}; user = {2}; password = {3}; database = {4};", appSettings.host, appSettings.port, appSettings.user, appSettings.pass, appSettings.database);
#endif

            optionsBuilder.UseMySQL(query);
        }
    }
}