using System;
using System.Collections.Generic;
using System.IO;
using FireWoodLib.Types.UserHandler;

namespace FireWoodLib.Types.Log
{
    public class LogFile
    {
        public string FileName { get; set; }
        public string Data { get; set; }
        public List<string> DataList { get; set; }

        public LogFile(string fileName, string data, List<string> dataArray)
        {
            fileName = FileName;
            data = Data;
            dataArray = DataList;
        }

        public void Write(User user)
        {
            DateTime dateMade = DateTime.Now;

            string ContentToWrite = dateMade.ToString() + " | " + user.Username + " | " + this.Data;

            if (!File.Exists(this.FileName + ".txt"))
            {
                FileStream fs  = File.Create(this.FileName + ".txt");
                fs.Close();
            }
            
            File.AppendAllText(this.FileName, ContentToWrite);
        }
        
        public void WriteArray(User user)
        {
            DateTime dateMade = DateTime.Now;

            string ContentToWrite = dateMade.ToString() + " | " + user.Username + " | " + this.DataList.ToString();
            
            if (!File.Exists(this.FileName + ".txt"))
            {
                FileStream fs = File.Create(this.FileName + ".txt");
                fs.Close();
            }
            
            File.AppendAllText(this.FileName, ContentToWrite);
        }
    }
}