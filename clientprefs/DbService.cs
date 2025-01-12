﻿using clientprefs.Config;
using clientprefs.Database;
using clientprefs.Database.TableModel;
using System.Data;
using static s2sdk.s2sdk;

namespace clientprefs
{
    public unsafe class DbService : IDisposable
    {
        private IDatabase _databaseContext;
        private Dictionary<int, Cookie> _availableCookies;

        public Dictionary<ulong, List<UserCookie>> Users { get; init; }

        public DbService()
        {
            Users = new Dictionary<ulong, List<UserCookie>>();

            _databaseContext = GetContext();
            _databaseContext.InitDatabase();

            _availableCookies = GetAvailableCookies();
        }

        public void Dispose()
        {
            _databaseContext.Dispose();
        }

        private IDatabase GetContext()
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

        private Dictionary<int, Cookie> GetAvailableCookies()
        {
            DataTable table = _databaseContext.ExecuteTable(_databaseContext.GetQueryValidCookies());
            return table.AsEnumerable().Select(x => new Cookie(x)).ToDictionary(k => k.id, v => v);
        }

        public void LoadClientCookie(int clientIndex)
        {
            ulong accountId = GetClientAccountId(clientIndex);

            _databaseContext.Parameters["@accountId"] = accountId;
            DataTable table = _databaseContext.ExecuteTable(_databaseContext.GetQueryClientCookie());
            Users[accountId] = table.AsEnumerable().Select(x => new UserCookie(x)).ToList();

            Api.OnClientCookiesCached_Invoke(clientIndex);
        }

        public void ClearClientCookie(int clientIndex)
        {
            Users.Remove(GetClientAccountId(clientIndex));
        }

        public int RegisterClientCookie(string name, string description)
        {
            int cookieId = _availableCookies.FirstOrDefault(x => x.Value.name == name).Key;

            if(cookieId == 0)
            {
                _databaseContext.Parameters["@name"] = name;
                _databaseContext.Parameters["@description"] = description;
                cookieId = _databaseContext.ExecuteNonQuery(_databaseContext.GetQueryInsertCookie());

                _availableCookies[cookieId] = new Cookie(cookieId, name, description);
            }

            return cookieId;
        }

        public void SetClientCookie(int cookieId, ulong accountId, string value)
        {
            if(AreCookieAvailable(cookieId) == false || AreClientCookiesCached(accountId) == false)
            {
                return;
            }

            UserCookie? userCookie = Users[accountId].FirstOrDefault(x => x.cookieId == cookieId);

            if(userCookie == null)
            {
                userCookie = new UserCookie(accountId, cookieId, value);
                Users[accountId].Add(userCookie);
            }
            else
            {
                userCookie.value = value;
            }

            _databaseContext.Parameters["@accountId"] = userCookie.accountId;
            _databaseContext.Parameters["@cookieId"] = userCookie.cookieId;
            _databaseContext.Parameters["@value"] = userCookie.value;
            _databaseContext.ExecuteNonQuery(_databaseContext.GetQueryInsertOrUpdateClientCookie());
        }

        public string GetClientCookie(int cookieId, ulong accountId)
        {
            if(AreCookieAvailable(cookieId) == false || AreClientCookiesCached(accountId) == false)
            {
                return string.Empty;
            }

            UserCookie? userCookie = Users[accountId].FirstOrDefault(x => x.cookieId == cookieId);

            if(userCookie == null)
            {
                return string.Empty;
            }

            return userCookie.value;
        }

        public bool AreCookieAvailable(int cookieId)
        {
            return _availableCookies.ContainsKey(cookieId);
        }

        public bool AreClientCookiesCached(ulong accountId)
        {
            return Users.ContainsKey(accountId);
        }

        public bool AreClientCookiesCached(int clientIndex)
        {
            return AreClientCookiesCached(GetClientAccountId(clientIndex));
        }
    }
}