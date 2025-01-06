namespace clientprefs.Database.Table
{
    public class Cookie
    {
        public int id { get; set; }
        public string name { get; set; }
        public string? description { get; set; }

        public Cookie()
        {

        }

        public Cookie(string name, string? description)
        {
            this.name = name;
            this.description = description;
        }
    }
}