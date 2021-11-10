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

        public void Write(LogFile log, User user)
        {
            DateTime dateMade = DateTime.Now;

            string ContentToWrite = dateMade.ToString() + " | " + user.Username + " | " + log.Data;
            
            File.AppendAllText(log.FileName, ContentToWrite);
        }
        
        public void WriteArray(LogFile log, User user)
        {
            DateTime dateMade = DateTime.Now;

            string ContentToWrite = dateMade.ToString() + " | " + user.Username + " | " + log.DataList.ToString();

            File.AppendAllText(log.FileName, ContentToWrite);
        }
    }
}