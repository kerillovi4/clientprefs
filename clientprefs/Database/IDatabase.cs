using System.Data;
using System.Data.Common;

namespace clientprefs.Database
{
    public interface IDatabase
    {
        public string GET_VALID_COOKIES_QUERY { get; }
        public string GET_CLIENT_COOKIE_QUERY { get; }
        public string INSERT_COOKIE_QUERY { get; }
        public string INSERT_OR_UPDATE_CLIENT_COOKIE_QUERY { get; }

        public Dictionary<string, object> Parameters { get; init; }

        public void InitDatabase();
        public int ExecuteNonQuery(string query);
        public DbDataReader ExecuteReader(string query);
        public object? ExecuteScalar(string query);
        public DataTable ExecuteTable(string query);
    }
}