using clientprefs.Config;
using System.Data;
using System.Data.Common;

namespace clientprefs.Database
{
    public interface IDatabase : IDisposable
    {
        public Dictionary<string, object> Parameters { get; init; }

        public void InitDatabase();
        public int ExecuteNonQuery(string query);
        public DbDataReader ExecuteReader(string query);
        public object? ExecuteScalar(string query);
        public DataTable ExecuteTable(string query);

        public string GetQueryValidCookies()
        {
            return string.Format("select * from {0}cookie{1}", AppSettings.Instance.database_schema, AppSettings.Instance.database_prefix);
        }

        public string GetQueryClientCookie()
        {
            return string.Format("select * from {0}user_cookie{1} where account_id = @accountId", AppSettings.Instance.database_schema, AppSettings.Instance.database_prefix);
        }

        public string GetQueryInsertCookie()
        {
            return string.Format("insert into {0}cookie{1} (name, description) values (@name, @description)", AppSettings.Instance.database_schema, AppSettings.Instance.database_prefix);
        }

        public string GetQueryInsertOrUpdateClientCookie();
    }
}