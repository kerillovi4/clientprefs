using System.Data;

namespace clientprefs.Database.TableModel
{
    public class UserCookie
    {
        public ulong accountId { get; set; }
        public int cookieId { get; set; }
        public string value { get; set; }
        
        public UserCookie(ulong accountId, int cookieId, string value)
        {
            this.accountId = accountId;
            this.cookieId = cookieId;
            this.value = value;
        }

        public UserCookie(DataRow row) : this(Convert.ToUInt64(row["account_id"]), Convert.ToInt32(row["cookie_id"]), (string)row["value"])
        {

        }
    }
}