using clientprefs.Database;
using clientprefs.Database.Table;

namespace clientprefs
{
    public class DbService
    {
        private List<int> _validCookieIds;
        private DatabaseContext _databaseContext;

        public DbService()
        {
            _databaseContext = DatabaseContext.GetContext();
            _validCookieIds = _databaseContext.Cookies.Select(x => x.id).ToList();
        }

        public List<UserCookie> GetClientCookies(ulong accountId)
        {
            return _databaseContext.UsersCookie.Where(x => x.accountId == accountId).ToList();
        }

        public int RegisterClientCookie(string name, string description)
        {
            Cookie? cookie = _databaseContext.Cookies.FirstOrDefault(x => x.name == name);

            if(cookie == null)
            {
                cookie = new Cookie(name, description);

                _databaseContext.Cookies.Add(cookie);
                _databaseContext.SaveChanges();

                _validCookieIds.Add(cookie.id);
            }

            return cookie.id;
        }

        public void SetClientCookie(int cookieId, ulong accountId, string value)
        {
            if(_validCookieIds.Contains(cookieId))
            {
                return;
            }

            UserCookie? userCookie = _databaseContext.UsersCookie.FirstOrDefault(x => x.cookieId == cookieId && x.accountId == accountId);

            if(userCookie == null)
            {
                userCookie = new UserCookie(accountId, cookieId, value);

                _databaseContext.UsersCookie.Add(userCookie);
            }
            else
            {
                userCookie.value = value;
            }

            _databaseContext.SaveChanges();
        }

        public string GetClientCookie(int cookieId, ulong accountId)
        {
            if(_validCookieIds.Contains(cookieId))
            {
                return string.Empty;
            }

            UserCookie? userCookie = _databaseContext.UsersCookie.FirstOrDefault(x => x.cookieId == cookieId && x.accountId == accountId);

            if(userCookie == null)
            {
                return string.Empty;
            }
            
            return userCookie.value;
        }
    }
}