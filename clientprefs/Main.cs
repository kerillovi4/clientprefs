using clientprefs.Config;
using clientprefs.Database.Table;
using Plugify;
using static s2sdk.s2sdk;

namespace clientprefs
{
    public unsafe class Main : Plugin
    {
        private static Main _instance;
        public static Main Instance => _instance;
        private static List<Action<int>> _forwards = new List<Action<int>>();

        public DbService DbService { get; private set; }
        public Dictionary<ulong, List<UserCookie>> Users { get; } = new Dictionary<ulong, List<UserCookie>>();

        public Main()
        {
            _instance = this;
        }

        public void OnPluginStart()
        {
            AppSettings.Load();
            DbService = new DbService();

            //OnClientAuthenticated_Register(OnClientAuthenticatedCallback);
            OnClientPutInServer_Register(OnClientPutInServerCallback);
            //OnClientConnect_Register(OnClientConnectCallback);
            OnClientDisconnect_Post_Register(OnClientDisconnect_PostCallback);
        }

        private void OnClientAuthenticatedCallback(int clientIndex, ulong accountId)
        {
            PrintToServer(string.Format("\n>>>>>>>OnClientAuthenticatedCallback>>> {0} | {1}\n", clientIndex, accountId));
        }

        private void OnClientPutInServerCallback(int clientIndex)
        {
            if(IsFakeClient(clientIndex))
            {
                return;
            }

            ulong accountId = GetClientAccountId(clientIndex);
            PrintToServer(string.Format("\n>>>>>>>OnClientPutInServerCallback>>> {0} | {1}\n", clientIndex, accountId));

            Users[accountId] = DbService.GetClientCookies(accountId);
            _forwards.ForEach(x => x?.Invoke(clientIndex));
        }

        private Bool8 OnClientConnectCallback(int clientIndex, string name, string networkId)
        {
            if(IsFakeClient(clientIndex))
            {
                return false;
            }

            ulong accountId = GetClientAccountId(clientIndex);
            PrintToServer(string.Format("\n>>>>>>>OnClientConnectCallback>>> {0} | {1}\n", clientIndex, accountId));

            return true;
        }

        private void OnClientDisconnect_PostCallback(int clientIndex, int reason)
        {
            if(IsFakeClient(clientIndex))
            {
                return;
            }

            ulong accountId = GetClientAccountId(clientIndex);
            PrintToServer(string.Format("\n>>>>>>>OnClientDisconnect_PostCallback>>> {0} | {1}\n", clientIndex, reason));

            Users.Remove(accountId);
        }

        public static void OnClientCookiesCached_Register(Action<int> callback)
        {
            _forwards.Add(callback);
        }

        public static void OnClientCookiesCached_UnRegister(Action<int> callback)
        {
            _forwards.Remove(callback);
        }

        public static int RegisterClientCookie(string name, string description)
        {
            //return _instance.DbService.RegisterClientCookie(name, description);

            PrintToServer(string.Format(">>>>>>>>>>>>>>>>>>>>>>>>>>RegisterClientCookie_Pre | {0} | {1}", name, description));
            int tmp = _instance.DbService.RegisterClientCookie(name, description);
            PrintToServer(string.Format(">>>>>>>>>>>>>>>>>>>>>>>>>>RegisterClientCookie_Post | {0} | {1} | {2}", name, description, tmp));
            return tmp;
        }

        public static void SetClientCookie(int cookieId, int clientIndex, string value)
        {
            PrintToServer(string.Format(">>>>>>>>>>>>>>>>>>>>>>>>>>SetClientCookie_Pre | {0} | {1} | {2}", cookieId, GetClientAccountId(clientIndex), value));
            _instance.DbService.SetClientCookie(cookieId, GetClientAccountId(clientIndex), value);
            PrintToServer(string.Format(">>>>>>>>>>>>>>>>>>>>>>>>>>SetClientCookie_Post | {0} | {1} | {2}", cookieId, GetClientAccountId(clientIndex), value));
        }

        public static string GetClientCookie(int cookieId, int clientIndex)
        {
            //return _instance.DbService.GetClientCookie(cookieId, GetClientAccountId(clientIndex));

            PrintToServer(string.Format(">>>>>>>>>>>>>>>>>>>>>>>>>>GetClientCookie_Pre | {0} | {1}", cookieId, GetClientAccountId(clientIndex)));
            string tmp = _instance.DbService.GetClientCookie(cookieId, GetClientAccountId(clientIndex));
            PrintToServer(string.Format(">>>>>>>>>>>>>>>>>>>>>>>>>>GetClientCookie_Post | {0} | {1} | {2}", cookieId, GetClientAccountId(clientIndex), tmp));
            return tmp;
        }

        public static bool AreClientCookiesCached(int clientIndex)
        {
            //return _instance.Users.ContainsKey(GetClientAccountId(clientIndex));

            PrintToServer(string.Format(">>>>>>>>>>>>>>>>>>>>>>>>>>AreClientCookiesCached_Pre | {0}", GetClientAccountId(clientIndex)));
            bool tmp = _instance.Users.ContainsKey(GetClientAccountId(clientIndex));
            PrintToServer(string.Format(">>>>>>>>>>>>>>>>>>>>>>>>>>AreClientCookiesCached_Pre | {0} | {1}", GetClientAccountId(clientIndex), tmp));
            return tmp;
        }
    }
}