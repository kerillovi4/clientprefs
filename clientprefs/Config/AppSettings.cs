using Newtonsoft.Json;

namespace clientprefs.Config
{
    public class AppSettings
    {
        public const string DriverMySQL = "mysql";
        public const string DriverNpgsql = "postgresql";
        public const string DriverSqlite = "sqlite";

        private static AppSettings _instance;
        public static AppSettings Instance => _instance;

        public string driver { get; set; }
        public string host { get; set; }
        public string database { get; set; }
        public string user { get; set; }
        public string pass { get; set; }
        public int port { get; set; }

        private AppSettings()
        {

        }

        public static void Load()
        {
            string path = Path.Combine(Main.Instance.BaseDir, "appsettings.json");

            if(File.Exists(path) == false)
            {
                _instance = new AppSettings();
                File.WriteAllText(path, JsonConvert.SerializeObject(_instance));
            }
            else
            {
                string json = File.ReadAllText(path);
                _instance = JsonConvert.DeserializeObject<AppSettings>(json);
            }
        }
    }
}