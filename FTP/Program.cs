using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FTP
{
    internal class Program
    {
        static void Main(string[] args) => new Program().Code();
        public void Code()
        {
            int start_time = int.Parse(DateTime.Now.ToString());
            FtpWebRequest fwr = (FtpWebRequest)WebRequest.Create("ftp://ftp.dlptest.com");
            fwr.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            fwr.Credentials = new NetworkCredential("dlpuser", "rNrKYTX9g7z3RgJRmxWuGHbeu");
            FtpWebResponse fwr_ = (FtpWebResponse)fwr.GetResponse();
            Stream stream = fwr_.GetResponseStream();
            FileStream fs = new FileStream("\\\\Keenetic-9922\\внешний диск\\сетевое программирование\\FTP\\FTP\\bin\\Debug\\ftp.txt", FileMode.Create);
            byte[] buffer = new byte[64];
            int size = 0;//размер
            while ((size = stream.Read(buffer, 0, buffer.Length)) > 0) fs.Write(buffer, 0, size);
            fs.Close();
            fwr_.Close();
            string content = stream.Read(buffer, 0, buffer.Length).ToString();
            Console.WriteLine(content);
            int end_time = int.Parse(DateTime.Now.ToString()),
                difference = end_time - start_time,
                speed = buffer.Length / difference;
            Console.WriteLine($"{speed} байтов в секунду");
        }
    }
}