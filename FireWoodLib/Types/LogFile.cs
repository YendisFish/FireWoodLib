using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using FireWoodLib.DefaultSetter;
using FireWoodLib.Types.UserHandler;

namespace FireWoodLib.Types.Log
{
    public class LogFile
    {
        public string FileName { get; set; }
        public string Data { get; set; }
        public List<string> DataList { get; set; }
        public Defaults Defaults { get; set; }

        public string LogDir { get; set; }

        public LogFile(string fileName, string data, List<string> dataArray, Defaults defaults)
        {
            this.FileName = fileName;
            this.Data = data;
            this.DataList = dataArray;
            this.Defaults = defaults;
        }

        public void Write(User user)
        {
            DateTime dateMade = DateTime.Now;

            string ContentToWrite = dateMade.ToString() + " | " + user.Username + " | " + this.Data;

            if (!File.Exists(this.LogDir))
            {
                FileStream fs  = File.Create(this.LogDir);
                fs.Close();
            }
            
            File.AppendAllText(this.LogDir, ContentToWrite);
        }
        
        public void WriteArray(User user)
        {
            DateTime dateMade = DateTime.Now;

            string ContentToWrite = dateMade.ToString() + " | " + user.Username + " | " + this.DataList.ToString();
            
            if (!File.Exists(this.LogDir))
            {
                FileStream fs = File.Create(this.LogDir);
                fs.Close();
            }
            
            File.AppendAllText(this.LogDir, ContentToWrite);
        }

        public LogFile ImportLogFile(string fileName)
        {
            if (File.Exists(fileName + ".txt"))
            {
                this.FileName = fileName;
                this.Data = File.ReadAllText(fileName + ".txt");
                this.DataList = File.ReadLines(fileName + ".txt").ToList();
                
                FileInfo fleInf = new FileInfo(fileName);
                DirectoryInfo fleDir = fleInf.Directory;

                this.Defaults.LogPath = fleDir.ToString();

                return new LogFile(this.FileName, this.Data, this.DataList, this.Defaults);
            }

            return null;
        }

        public void SetDefaultDirs()
        {
            this.LogDir = Path.Combine(new string[] {this.Defaults.LogPath, this.FileName + ".txt"});
        }
    }
}