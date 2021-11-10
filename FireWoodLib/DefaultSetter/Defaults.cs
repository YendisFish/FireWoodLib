using System.IO;
using Newtonsoft.Json;

namespace FireWoodLib.DefaultSetter
{
    public class Defaults
    {
        public string LogPath { get; set; }
        public string UserDirectory { get; set; }
        public string UserLogDirectory { get; set; }

        public Defaults(string LogPath, string UserDirectory, string UserLogDirectory)
        {
            this.LogPath = LogPath;
            this.UserDirectory = UserDirectory;
            this.UserLogDirectory = UserLogDirectory;
        }

        public void CreateDirs()
        {
            if (!Directory.Exists(this.LogPath))
            {
                Directory.CreateDirectory(this.LogPath);
            }
            if (!Directory.Exists(this.UserDirectory))
            {
                Directory.CreateDirectory(this.UserDirectory);
            }
            if (!Directory.Exists(this.UserLogDirectory))
            {
                Directory.CreateDirectory(this.UserLogDirectory);
            }
        }

        public string ConvertToJson()
        {
            string toRet = JsonConvert.SerializeObject(this);
            return toRet;
        }
    }
}