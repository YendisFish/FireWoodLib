namespace FireWoodLib.DefaultSetter
{
    public class Defaults
    {
        public string LogPath { get; set; }
        public string UserDirectory { get; set; }
        public string UserLogDirectory { get; set; }

        public Defaults(string logPath, string userDirectory, string userLogDirectory)
        {
            this.LogPath = logPath;
            this.UserDirectory = userDirectory;
            this.UserLogDirectory = userLogDirectory;
        }
    }
}