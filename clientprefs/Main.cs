using clientprefs.Config;
using Plugify;
using static s2sdk.s2sdk;

namespace clientprefs
{
    public unsafe class Main : Plugin
    {
        private static Main _instance;
        public static Main Instance => _instance;

        public DbService DbService { get; private set; }

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

        public void OnPluginEnd()
        {
            DbService?.Dispose();
        }

        private void OnClientPutInServerCallback(int clientIndex)
        {
            if(IsFakeClient(clientIndex))
            {
                return;
            }

            DbService.LoadClientCookie(clientIndex);
        }

        private void OnClientDisconnect_PostCallback(int clientIndex, int reason)
        {
            if(IsFakeClient(clientIndex))
            {
                return;
            }

            DbService.ClearClientCookie(clientIndex);
        }
    }
}