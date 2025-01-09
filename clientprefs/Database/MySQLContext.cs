using clientprefs.Config;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;

namespace clientprefs.Database
{
    internal class MySQLContext : IDatabase
    {
        private MySqlConnection _connection;

        public Dictionary<string, object> Parameters { get; init; }

        public MySQLContext()
        {
            AppSettings appSettings = AppSettings.Instance;

            string connectionString = string.Format("server = {0}; port = {1}; user = {2}; password = {3}; database = {4};", appSettings.host, appSettings.port, appSettings.user, appSettings.pass, appSettings.database);
            _connection = new MySqlConnection(connectionString);
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
            MySqlTransaction transaction = _connection.BeginTransaction();

            using(MySqlCommand command = new MySqlCommand("create table if not exists cookie (id int(11) not null auto_increment, name varchar(64) not null, description varchar(512) null, primary key (id)) default charset = utf8mb4", _connection, transaction))
            {
                command.ExecuteNonQuery();
            }
            using(MySqlCommand command = new MySqlCommand("create table if not exists user_cookie (account_id bigint(20) unsigned not null, cookie_id int(11) not null, value longtext not null, primary key (account_id, cookie_id), index ix_user_cookie_cookie_id (cookie_id), constraint fk_user_cookie_cookie_cookie_id foreign key (cookie_id) references cookie (id) on update restrict on delete cascade) default charset = utf8mb4", _connection, transaction))
            {
                command.ExecuteNonQuery();
            }

            transaction.Commit();
            transaction.Dispose();
        }

        public int ExecuteNonQuery(string query)
        {
            using MySqlCommand command = new MySqlCommand(query, _connection);
            command.AddParameres(Parameters);
            int result = command.ExecuteNonQuery();

            Parameters.Clear();

            return result;
        }

        public DbDataReader ExecuteReader(string query)
        {
            using MySqlCommand command = new MySqlCommand(query, _connection);
            command.AddParameres(Parameters);
            DbDataReader result = command.ExecuteReader();

            Parameters.Clear();

            return result;
        }

        public object? ExecuteScalar(string query)
        {
            using MySqlCommand command = new MySqlCommand(query, _connection);
            command.AddParameres(Parameters);
            object? reuslt = command.ExecuteScalar();

            Parameters.Clear();

            return reuslt;
        }

        public DataTable ExecuteTable(string query)
        {
            using MySqlCommand command = new MySqlCommand(query, _connection);
            command.AddParameres(Parameters);

            using MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            Parameters.Clear();

            return table;
        }

        public string GetQueryInsertOrUpdateClientCookie()
        {
            return string.Format("insert into user_cookie{0} (account_id, cookie_id, value) values (@accountId, @cookieId, @value) on duplicate key update value = @value", AppSettings.Instance.database_prefix);
        }
    }
}