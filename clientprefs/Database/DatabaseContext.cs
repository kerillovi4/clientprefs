using clientprefs.Config;
using clientprefs.Database.Table;
using Microsoft.EntityFrameworkCore;

namespace clientprefs.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Cookie> Cookies { get; set; }
        public DbSet<UserCookie> UsersCookie { get; set; }

        public DatabaseContext()
        {
            Database.Migrate();
        }

        public static DatabaseContext GetContext()
        {
            switch(AppSettings.Instance.driver)
            {
                case AppSettings.DriverMySQL:
                    return new MySQLContext();

                case AppSettings.DriverNpgsql:
                    return new NpgsqlContext();

                case AppSettings.DriverSqlite:
                    return new SqliteContext();
            }

            throw new NotSupportedException(AppSettings.Instance.driver);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cookie>((buildAction) =>
            {
                buildAction.HasKey(x => x.id);

                buildAction.Property(x => x.name).HasMaxLength(64);
                buildAction.Property(x => x.description).HasMaxLength(512);

                buildAction.ToTable("cookie");
            });

            modelBuilder.Entity<UserCookie>((buildAction) =>
            {
                buildAction.HasKey(x => x.accountId);

                buildAction.Property(x => x.accountId).HasColumnName("account_id");
                buildAction.Property(x => x.cookieId).HasColumnName("cookie_id");

                buildAction.HasOne(x => x.Cookie).WithMany().HasForeignKey(x => x.cookieId);

                buildAction.ToTable("user_cookie");
            });
        }
    }
}