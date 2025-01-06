namespace clientprefs.Database.Table
{
    public class UserCookie
    {
        public ulong accountId { get; set; }
        public int cookieId { get; set; }
        public string value { get; set; }

        public virtual Cookie Cookie { get; set; }

        public UserCookie()
        {
            
        }

        public UserCookie(ulong accountId, int cookieId, string value)
        {
            this.accountId = accountId;
            this.cookieId = cookieId;
            this.value = value;
        }
    }
}