using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_2
{
    public class Reader
    {
        public string PathRead { get; set; }
        public string PathWrite { get; set; }
        public string Data { get; set; }
        public Reader(string pathRead, string pathWrite)
        {
            PathRead = pathRead;
            PathWrite = pathWrite;
        }

        public Reader()
        {
            PathRead = ConfigurationManager.AppSettings["FilePathRead"];
            PathWrite = ConfigurationManager.AppSettings["FilePathWrite"];
        }

        public string ReadData()
        {
            using (StreamReader sr = new StreamReader(PathRead))
            {
                Data = sr.ReadToEnd();
                sr.Close();
            }
            return Data;
        }

        public bool WriteData()
        {
            using (StreamWriter sw = new StreamWriter(PathWrite))
            {
                sw.Write(Data);
                sw.Flush();
                sw.Close();
            }
            return true;
        }
    }
}
