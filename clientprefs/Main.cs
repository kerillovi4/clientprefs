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

            OnClientPutInServer_Register(OnClientPutInServerCallback);
            OnClientDisconnect_Post_Register(OnClientDisconnect_PostCallback);
        }

        private void OnClientPutInServerCallback(int clientIndex)
        {
            if(IsFakeClient(clientIndex))
            {
                return;
            }

            ulong accountId = GetClientAccountId(clientIndex);

            Users[accountId] = DbService.GetClientCookies(accountId);
            Api.OnClientCookiesCached_Invoke(clientIndex);
        }

        private void OnClientDisconnect_PostCallback(int clientIndex, int reason)
        {
            if(IsFakeClient(clientIndex))
            {
                return;
            }

            Users.Remove(GetClientAccountId(clientIndex));
        }
    }
}