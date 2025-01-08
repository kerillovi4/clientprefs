using clientprefs.Config;
using clientprefs.Database;
using clientprefs.Database.TableModel;
using System.Data;
using static s2sdk.s2sdk;

namespace clientprefs
{
    public unsafe class DbService
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

        private IDatabase GetContext()
        {
            AppSettings appSettings = AppSettings.Instance;

            switch(appSettings.driver)
            {
                case AppSettings.DriverMySQL:
                    return new MySQLContext(appSettings);

                case AppSettings.DriverNpgsql:
                    return new NpgsqlContext(appSettings);

                case AppSettings.DriverSqlite:
                    return new SqliteContext(appSettings);
            }

            throw new NotSupportedException(AppSettings.Instance.driver);
        }

        private Dictionary<int, Cookie> GetAvailableCookies()
        {
            DataTable table = _databaseContext.ExecuteTable(_databaseContext.GET_VALID_COOKIES_QUERY);
            return table.AsEnumerable().Select(x => new Cookie(x)).ToDictionary(k => k.id, v => v);
        }

        public void LoadClientCookie(int clientIndex)
        {
            ulong accountId = GetClientAccountId(clientIndex);

            _databaseContext.Parameters["@accountId"] = accountId;
            DataTable table = _databaseContext.ExecuteTable(_databaseContext.GET_CLIENT_COOKIE_QUERY);
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
                cookieId = _databaseContext.ExecuteNonQuery(_databaseContext.INSERT_COOKIE_QUERY);

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
            _databaseContext.ExecuteNonQuery(_databaseContext.INSERT_OR_UPDATE_CLIENT_COOKIE_QUERY);
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