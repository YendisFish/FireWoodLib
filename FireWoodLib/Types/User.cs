using System;
using System.IO;
using FireWoodLib.DefaultSetter;
using Newtonsoft.Json;

namespace FireWoodLib.Types.UserHandler
{
    public class User
    {
        public string Username { get; set; }
        public string UserToken { get; set; }
        public Defaults Defaults { get; set; }

        public string UserDir { get; set; }

        public User(string username, string userToken, Defaults defaults)
        {
            this.Username = username;
            this.UserToken = userToken;
            this.Defaults = defaults;
        }

        public string[] CombineAllData()
        {
            string[] Combined = {Username, UserToken};
            return Combined;
        }
        
        public void CreateAndSetUser()
        {
            string UserToWrite = JsonConvert.SerializeObject(this);

            if (!File.Exists(this.UserDir))
            {
                FileStream fs = File.Create(this.UserDir);
                fs.Close();
            }
            
            File.WriteAllText(this.UserDir, UserToWrite);
        }

        public void SetDefaultDirs()
        {
            this.UserDir = Path.Combine(new string[] {this.Defaults.UserDirectory, this.UserToken + ".json"});
        }

        public User ImportUser(string path)
        {
            User toRet = JsonConvert.DeserializeObject<User>(File.ReadAllText(path));
            return toRet;
        }
    }
}