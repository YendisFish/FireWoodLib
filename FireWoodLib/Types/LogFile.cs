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
        public string[] DataArray { get; set; }
        public Defaults Defaults { get; set; }

        public string LogDir { get; set; }

        public string newLine = System.Environment.NewLine;

        public LogFile(string FileName, string Data, string[] DataArray, Defaults Defaults)
        {
            this.FileName = FileName;
            this.Data = Data;
            this.DataArray = DataArray;
            this.Defaults = Defaults;
        }

        public void WriteData()
        {
            DateTime dateMade = DateTime.Now;

            string ContentToWrite = dateMade.ToString() + " | " + this.Data;
            
            List<string> counter = File.ReadAllLines(this.LogDir).ToList();

            if (counter.Count == 0)
            {
                File.WriteAllText(this.LogDir, ContentToWrite);
            }
            else
            {
                File.AppendAllText(this.LogDir, newLine + ContentToWrite);
            }
        }
        
        public void WriteDataArray()
        {
            DateTime dateMade = DateTime.Now;

            string ContentToWrite = dateMade.ToString() + " | " + this.DataArray.ToString();
            
            List<string> counter = File.ReadAllLines(this.LogDir).ToList();

            if (counter.Count == 0)
            {
                File.WriteAllText(this.LogDir, ContentToWrite);
            }
            else
            {
                File.AppendAllText(this.LogDir, newLine + ContentToWrite);
            }
        }

        public LogFile ImportLogFile(string fileName)
        {
            if (File.Exists(fileName + ".txt"))
            {
                this.FileName = fileName;
                this.Data = File.ReadAllText(fileName + ".txt");
                
                List<string> ToCast = File.ReadLines(fileName + ".txt").ToList();
                
                this.DataArray = ToCast.ToArray();
                
                FileInfo fleInf = new FileInfo(fileName);
                DirectoryInfo fleDir = fleInf.Directory;

                this.Defaults.LogPath = fleDir.ToString();

                return new LogFile(this.FileName, this.Data, this.DataArray, this.Defaults);
            }

            return null;
        }

        public void SetDefaultDirs()
        {
            this.LogDir = Path.Combine(new string[] {this.Defaults.LogPath, this.FileName + ".txt"});
        }

        public void Write(User user, string data)
        {
            DateTime date = DateTime.Now;

            string toWrite = $"{date} | {user.Username} | {data.ToString()}";

            List<string> counter = File.ReadAllLines(this.LogDir).ToList();

            if (counter.Count == 0)
            {
                File.WriteAllText(this.LogDir, toWrite);
            }
            else
            {
                File.AppendAllText(this.LogDir, newLine + toWrite);
            }
        }

        public void WriteArray(User user, string[] data)
        {
            DateTime date = DateTime.Now;
            
            string dat = "";
            
            foreach (string val in data)
            {
                dat = dat + data;
            }
            
            string toWrite = $"{date} | {user.Username} | {dat.ToString()}";
            
            List<string> counter = File.ReadAllLines(this.LogDir).ToList();

            if (counter.Count == 0)
            {
                File.WriteAllText(this.LogDir, toWrite);
            }
            else
            {
                File.AppendAllText(this.LogDir, newLine + toWrite);
            }
        }

        public void WriteArrayAsLines(User user, string[] data)
        {
            DateTime date = DateTime.Now;

            string Header = date + " | " + user.Username + " | {";

            List<string> dataList = new();
            
            foreach (string value in data)
            {
                dataList.Add("  " + value);
            }
            
            File.AppendAllText(this.LogDir, Header);
            File.AppendAllLines(this.LogDir, dataList);
            File.AppendAllText(this.LogDir, "}");
        }

        public void ClearLog()
        {
            File.WriteAllText(this.LogDir, "");
        }

        public void WriteError(string ErrorMessage)
        {
            string Emessage = "ERROR: " + ErrorMessage;
            
            File.AppendAllText(this.LogDir, Emessage);
        }

        public string[] GetLines()
        {
            string[] ret = File.ReadAllLines(this.LogDir);
            return ret;
        }

        public string ReadLog()
        {
            string ret = File.ReadAllText(this.LogDir);
            return ret;
        }

        public void CreateLog()
        {
            if (!File.Exists(this.LogDir))
            {
                FileStream fs = File.Create(this.LogDir);
                fs.Close();
            }
        }

        public void WriteRaw(string data)
        {
            List<string> counter = File.ReadAllLines(this.LogDir).ToList();

            if (counter.Count == 0)
            {
                File.WriteAllText(this.LogDir, data);
            }
            else
            {
                File.AppendAllText(this.LogDir, newLine + data);
            }
        }

        public void DeleteLog()
        {
            File.Delete(this.LogDir);
        }
    }
}