using System;
using System.IO;
using Newtonsoft.Json;

namespace FireWoodLib.Types.UserHandler
{
    public class User
    {
        public string Username { get; set; }
        public string UserToken { get; set; }

        public User(string username, string userToken)
        {
            username = Username;
            userToken = UserToken;
        }

        public string[] CombineAllData()
        {
            string[] Combined = {Username, UserToken};
            return Combined;
        }
        
        public void CreateAndSetUser(User user)
        {
            string UserToWrite = JsonConvert.SerializeObject(user);

            if (!File.Exists(user.UserToken + ".json"))
            {
                FileStream fs = File.Create(user.UserToken + ".json");
                fs.Close();
            }
            
            File.WriteAllText(user.UserToken + ".json", UserToWrite);
        }
    }
}