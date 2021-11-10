using System;

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
    }
}