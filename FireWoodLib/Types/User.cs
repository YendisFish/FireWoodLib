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

        public User(string Username, string UserToken, Defaults Defaults)
        {
            this.Username = Username;
            this.UserToken = UserToken;
            this.Defaults = Defaults;
        }

        public string[] CombineAllData()
        {
            string[] Combined = {Username, UserToken};
            return Combined;
        }
        
        public void CreateAndSetUser()
        {
            CheckForExistingUser();
            
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
            if (this.UserToken != null)
            {
                this.UserDir = Path.Combine(new string[] {this.Defaults.UserDirectory, this.UserToken + ".json"});                
            }
            else
            {
                this.UserDir = Path.Combine(new string[] {this.Defaults.UserDirectory, "EMPTYTOKEN-" + Guid.NewGuid().ToString() + ".json"}); 
            }
        }

        public User ImportUser(string path)
        {
            User toRet = JsonConvert.DeserializeObject<User>(File.ReadAllText(path));
            return toRet;
        }
        
        public void SetUserToken()
        {
            this.UserToken = Guid.NewGuid().ToString();
        }
        
        public string GenerateUserToken()
        {
            string ret = Guid.NewGuid().ToString();
            return ret;
        }

        public void CheckForExistingUser()
        {
            if (this.UserDir.Contains(this.UserToken))
            {
                this.UserToken = Guid.NewGuid().ToString();
            }
        }

        public User Clone()
        {
            User toRet = new User(this.Username, Guid.NewGuid().ToString(), this.Defaults);
            return toRet;
        }
    }
}