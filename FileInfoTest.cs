using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SteamTest
{
    public static class FileInfoTest
    {
        public static void FileInfomation(string filename)
        {
            var file = new FileInfo(filename);
            Console.WriteLine($"Name: {file.Name}");
            Console.WriteLine($"Directory: {file.Directory}");
            Console.WriteLine($"Read Only : {file.IsReadOnly}");
            Console.WriteLine($"Extension : {file.Extension}");
            Console.WriteLine($"Length : {file.Length}");
            Console.WriteLine($"CreationTime : {file.CreationTime:F}");
            Console.WriteLine($"LastAccessTime : {file.LastAccessTime:F}");
            Console.WriteLine($"Attributes : {file.Attributes}");
        }

        public static void CreateFile()
        {
            string path = Path.GetTempFileName();//创建临时文件
            var fileInfo = new FileInfo(path);
            using (StreamWriter sw = fileInfo.CreateText())
            {
                sw.WriteLine("Hi");
                sw.WriteLine("Rebecca");
            }

            using (StreamReader sr = fileInfo.OpenText())
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
            File.Delete(path);
        }
    }
}
