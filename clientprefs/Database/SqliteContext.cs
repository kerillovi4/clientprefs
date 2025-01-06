using clientprefs.Config;
using Microsoft.EntityFrameworkCore;

namespace clientprefs.Database
{
    //Add-Migration init -Context SqliteContext -OutputDir Migrations/SqliteMigrations

    public class SqliteContext : DatabaseContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string query;

            string path = Path.Combine(Main.Instance.BaseDir, "database");

            if(Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
            }

#if DEBUG
            query = string.Format("Data Source={0}", Path.Combine(path, "clientprefs.db"));
#else
            query = string.Format("Data Source={0}", Path.Combine(path, string.Concat(AppSettings.Instance.database, ".db")));
#endif

            optionsBuilder.UseSqlite(query);
        }
    }
}