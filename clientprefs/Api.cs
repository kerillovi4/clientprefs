using clientprefs.Database.Table;
using Plugify;
using static s2sdk.s2sdk;

namespace clientprefs
{
    public unsafe class Api
    {
        private static List<Delegate> _forwards = new List<Delegate>();

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
            return Main.Instance.DbService.RegisterClientCookie(name, description);
        }

        public static void SetClientCookie(int cookieId, int clientIndex, string value)
        {
            Main.Instance.DbService.SetClientCookie(cookieId, GetClientAccountId(clientIndex), value);
        }

        public static string GetClientCookie(int cookieId, int clientIndex)
        {
            ulong accountId = GetClientAccountId(clientIndex);

            if(AreClientCookiesCachedLocal(accountId) == false)
            {
                return string.Empty;
            }

            UserCookie? userCookie = Main.Instance.Users[accountId].FirstOrDefault(x => x.cookieId == cookieId);

            if(userCookie == null)
            {
                return string.Empty;
            }

            return userCookie.value;
        }

        public static Bool8 AreClientCookiesCached(int clientIndex)
        {
            return Main.Instance.Users.ContainsKey(GetClientAccountId(clientIndex));
        }

        private static bool AreClientCookiesCachedLocal(ulong accountId)
        {
            return Main.Instance.Users.ContainsKey(accountId);
        }
    }
}