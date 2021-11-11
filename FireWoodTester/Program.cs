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
            Console.WriteLine("Created user: " + TestUser.CombineAllData()[0] + " " + TestUser.CombineAllData()[1]);

            User TestImportUser = new User(null, null, null);
            TestImportUser = TestImportUser.ImportUser(TestUser.UserDir);
            TestImportUser.SetDefaultDirs();
            TestImportUser.CreateAndSetUser();
            Console.WriteLine("Imported user: " + TestImportUser.CombineAllData()[0] + " " + TestImportUser.CombineAllData()[1]);
            
            User ClonedUser = TestImportUser.Clone();
            ClonedUser.SetDefaultDirs();
            ClonedUser.CreateAndSetUser();
            Console.WriteLine("Cloned user: " + ClonedUser.CombineAllData()[0] + " " + ClonedUser.CombineAllData()[1]);
            

            LogFile TesterLogs = new LogFile("testerlog", null, null, TestDefaults);
            TesterLogs.SetDefaultDirs();
            TesterLogs.CreateLog();
            TesterLogs.Write(TestUser, "Hello World!");

            int lines = 1;
            foreach (string val in TesterLogs.GetLines())
            {
                Console.WriteLine(lines.ToString() + "| " + val);
                lines++;
            }
            
            Console.WriteLine("NoArray:");
            Console.WriteLine(TesterLogs.ReadLog());
        }
    }
}