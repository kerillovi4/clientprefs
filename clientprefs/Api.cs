using Plugify;
using static s2sdk.s2sdk;

namespace clientprefs
{
    public unsafe class Api
    {
        private static List<Delegate> _forwards = new List<Delegate>();
        private static DbService _dbService { get => Main.Instance.DbService; }

        public delegate void OnClientCookiesCachedCallback(int clientIndex);

        public static void OnClientCookiesCached_Register(OnClientCookiesCachedCallback callback)
        {
            if(_forwards.Contains(callback) == false)
            {
                _forwards.Add(callback);
            }
        }

        public static void OnClientCookiesCached_UnRegister(OnClientCookiesCachedCallback callback)
        {
            _forwards.Remove(callback);
        }

        public static void OnClientCookiesCached_Invoke(int clientIndex)
        {
            _forwards.ForEach(x => x.DynamicInvoke(clientIndex));
        }

        public static int RegisterClientCookie(string name, string description)
        {
            return _dbService.RegisterClientCookie(name, description);
        }

        public static void SetClientCookie(int cookieId, int clientIndex, string value)
        {
            _dbService.SetClientCookie(cookieId, GetClientAccountId(clientIndex), value);
        }

        public static string GetClientCookie(int cookieId, int clientIndex)
        {
            return _dbService.GetClientCookie(cookieId, GetClientAccountId(clientIndex));
        }

        public static Bool8 AreClientCookiesCached(int clientIndex)
        {
            return _dbService.AreClientCookiesCached(clientIndex);
        }
    }
}