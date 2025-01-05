using Plugify;
using static s2sdk.s2sdk;

namespace clientprefs
{
    public unsafe class Main : Plugin
    {
        public void OnPluginStart()
        {
            OnClientPutInServer_Register(OnClientPutInServerCallback);
        }

        private void OnClientPutInServerCallback(int clientIndex)
        {
            ulong accountId = GetClientAccountId(clientIndex);

            PrintToServer(string.Format(">>>> {0}", accountId.ToString()));
        }
    }
}