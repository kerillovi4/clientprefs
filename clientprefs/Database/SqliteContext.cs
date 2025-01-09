using clientprefs.Config;
using Microsoft.Data.Sqlite;
using System.Data;
using System.Data.Common;

namespace clientprefs.Database
{
    public class SqliteContext : IDatabase
    {
        private SqliteConnection _connection;

        public Dictionary<string, object> Parameters { get; init; }

        public SqliteContext()
        {
            string path = Path.Combine(Main.Instance.BaseDir, "database");

            if(Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
            }

            string connectionString = string.Format("Data Source = {0}", Path.Combine(path, string.Concat(AppSettings.Instance.database, ".db")));
            _connection = new SqliteConnection(connectionString);
            SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());
            _connection.Open();

            Parameters = new Dictionary<string, object>();
        }

        public void Dispose()
        {
            if(_connection.State == ConnectionState.Open)
            {
                _connection.Close();
                _connection.Dispose();
            }
        }

        public void InitDatabase()
        {
            SqliteTransaction transaction = _connection.BeginTransaction();

            using(SqliteCommand command = new SqliteCommand("create table if not exists cookie (id integer not null constraint pk_cookie primary key autoincrement, name text not null unique, description text null)", _connection, transaction))
            {
                command.ExecuteNonQuery();
            }
            using(SqliteCommand command = new SqliteCommand("create table if not exists user_cookie (account_id integer not null constraint pk_user_cookie, cookie_id integer not null, value text not null, primary key (account_id, cookie_id), constraint fk_user_cookie_cookie_cookie_id foreign key (cookie_id) references cookie (id) on delete cascade)", _connection, transaction))
            {
                command.ExecuteNonQuery();
            }

            transaction.Commit();
            transaction.Dispose();
        }

        public int ExecuteNonQuery(string query)
        {
            using SqliteCommand command = new SqliteCommand(query, _connection);
            command.AddParameres(Parameters);
            int result = command.ExecuteNonQuery();

            Parameters.Clear();

            return result;
        }

        public DbDataReader ExecuteReader(string query)
        {
            using SqliteCommand command = new SqliteCommand(query, _connection);
            command.AddParameres(Parameters);
            DbDataReader result = command.ExecuteReader();

            Parameters.Clear();

            return result;
        }

        public object? ExecuteScalar(string query)
        {
            using SqliteCommand command = new SqliteCommand(query, _connection);
            command.AddParameres(Parameters);
            object? reuslt = command.ExecuteScalar();

            Parameters.Clear();

            return reuslt;
        }

        public DataTable ExecuteTable(string query)
        {
            using SqliteCommand command = new SqliteCommand(query, _connection);
            command.AddParameres(Parameters);

            using SqliteDataReader reader = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);

            Parameters.Clear();

            return table;
        }

        public string GetQueryInsertOrUpdateClientCookie()
        {
            return string.Format("insert or replace into user_cookie{0} (account_id, cookie_id, value) values (@accountId, @cookieId, @value)", AppSettings.Instance.database_prefix);
        }
    }
}