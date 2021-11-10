using System;
using System.IO;
using FireWoodLib.DefaultSetter;
using FireWoodLib.Types.Log;
using FireWoodLib.Types.UserHandler;

namespace FireWoodTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tester INIT");

            if (!Directory.Exists("./TesterFiles"))
            {
                Directory.CreateDirectory("./TesterFiles");
            }

            Defaults TestDefaults = new Defaults("./TesterFiles/Logs", "./TesterFiles/Users", "./TesterFiles/UserLogs");
            TestDefaults.CreateDirs();
            
            User TestUser = new User("TestUser", null, TestDefaults);
            TestUser.SetUserToken();
            TestUser.SetDefaultDirs();
            TestUser.CreateAndSetUser();

            string TestUserDirecorySetter = TestUser.UserDir.Replace(TestUser.UserToken + ".json", "");
            
            User TestImportUser = new User(null, null, null);
            TestImportUser = TestImportUser.ImportUser(TestUser.UserDir);
            TestImportUser.SetDefaultDirs();
            TestImportUser.CreateAndSetUser();

            User ClonedUser = TestImportUser.Clone();
            ClonedUser.SetDefaultDirs();
            ClonedUser.CreateAndSetUser();

            LogFile TesterLogs = new LogFile("testerlog", null, null, TestDefaults);
            TesterLogs.SetDefaultDirs();
            TesterLogs.CreateLog();
            TesterLogs.Write(TestUser, "Hello World!");
        }
    }
}