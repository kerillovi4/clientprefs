using clientprefs.Config;
using Npgsql;
using System.Data;
using System.Data.Common;

namespace clientprefs.Database
{
    public class NpgsqlContext : IDatabase
    {
        private NpgsqlConnection _connection;

        public Dictionary<string, object> Parameters { get; init; }

        public NpgsqlContext()
        {
            AppSettings appSettings = AppSettings.Instance;

            string connectionString = string.Format("Server = {0}; Port = {1}; User Id = {2}; Password = {3}; Database = {4}", appSettings.host, appSettings.port, appSettings.user, appSettings.pass, appSettings.database);
            _connection = new NpgsqlConnection(connectionString);
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
            NpgsqlTransaction transaction = _connection.BeginTransaction();

            using(NpgsqlCommand command = new NpgsqlCommand("create table if not exists cookie (id serial, name character varying(64) not null, description character varying(512), primary key (id))", _connection, transaction))
            {
                command.ExecuteNonQuery();
            }
            using(NpgsqlCommand command = new NpgsqlCommand("create table if not exists user_cookie (account_id numeric(20,0) not null, cookie_id integer not null, value text not null, primary key (account_id, cookie_id), foreign key (cookie_id) references cookie (id) match simple on update no action on delete cascade)", _connection, transaction))
            {
                command.ExecuteNonQuery();
            }

            transaction.Commit();
            transaction.Dispose();
        }

        public int ExecuteNonQuery(string query)
        {
            using NpgsqlCommand command = new NpgsqlCommand(query, _connection);
            command.AddParameres(Parameters);
            int result = command.ExecuteNonQuery();

            Parameters.Clear();

            return result;
        }

        public DbDataReader ExecuteReader(string query)
        {
            using NpgsqlCommand command = new NpgsqlCommand(query, _connection);
            command.AddParameres(Parameters);
            DbDataReader result = command.ExecuteReader();

            Parameters.Clear();

            return result;
        }

        public object? ExecuteScalar(string query)
        {
            using NpgsqlCommand command = new NpgsqlCommand(query, _connection);
            command.AddParameres(Parameters);
            object? reuslt = command.ExecuteScalar();

            Parameters.Clear();

            return reuslt;
        }

        public DataTable ExecuteTable(string query)
        {
            using NpgsqlCommand command = new NpgsqlCommand(query, _connection);
            command.AddParameres(Parameters);

            using NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            Parameters.Clear();

            return table;
        }

        public string GetQueryInsertOrUpdateClientCookie()
        {
            return string.Format("insert into {0}user_cookie{1} (account_id, cookie_id, value) values (@accountId, @cookieId, @value) on conflict (account_id, cookie_id) do update set value = excluded.value", AppSettings.Instance.database_schema, AppSettings.Instance.database_prefix);
        }
    }
}