using System.Data;

namespace clientprefs.Database.TableModel
{
    public class Cookie
    {
        public int id { get; set; }
        public string name { get; set; }
        public string? description { get; set; }

        public Cookie(int id, string name, string? description)
        {
            this.id = id;
            this.name = name;
            this.description = description;
        }

        public Cookie(DataRow row) : this(Convert.ToInt32(row["id"]), (string)row["name"], (string)row["description"])
        {
            
        }
    }
}