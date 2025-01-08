using MySql.Data.MySqlClient;
using Npgsql;
using Microsoft.Data.Sqlite;

namespace clientprefs.Database
{
    public static class DatabaseCommadExtended
    {
        public static void AddParameres(this MySqlCommand command, Dictionary<string, object>? parameters)
        {
            if(parameters != null && parameters.Any())
            {
                command.Parameters.AddRange(parameters.Select(x => new MySqlParameter(x.Key, x.Value)).ToArray());
            }
        }

        public static void AddParameres(this NpgsqlCommand command, Dictionary<string, object>? parameters)
        {
            if(parameters != null && parameters.Any())
            {
                command.Parameters.AddRange(parameters.Select(x =>
                {
                    if(x.Value is ulong)
                    {
                        return new NpgsqlParameter(x.Key, NpgsqlTypes.NpgsqlDbType.Numeric)
                        {
                            Value = Convert.ToDecimal(x.Value)
                        };
                    }

                    return new NpgsqlParameter(x.Key, x.Value);
                }).ToArray());
            }
        }

        public static void AddParameres(this SqliteCommand command, Dictionary<string, object>? parameters)
        {
            if(parameters != null && parameters.Any())
            {
                command.Parameters.AddRange(parameters.Select(x => new SqliteParameter(x.Key, x.Value)));
            }
        }
    }
}