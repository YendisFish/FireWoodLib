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

            string UserDir = Path.Combine(new string[] {this.Defaults.UserDirectory, this.UserToken + "json"});
            
            if (!File.Exists(UserDir))
            {
                FileStream fs = File.Create(UserDir);
                fs.Close();
            }
            
            File.WriteAllText(this.UserToken + ".json", UserToWrite);
        }
        
        
    }
}