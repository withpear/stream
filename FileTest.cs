using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SteamTest
{
    public static class FileTest
    {
        public static void CreateFile()
        {
            var path = @"..\..\..\MyTest.txt"; //项目根目录下创建
            if (!File.Exists(path))
            {
                using (StreamWriter stream = File.CreateText(path))
                {
                    stream.WriteLine("Hello");
                    stream.WriteLine("CSharp");
                }
            }

            using (StreamReader stream = File.OpenText(path))
            {
                string s;
                while ((s = stream.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
        }

        //读取所有行，返回字符串数组
        public static void ReadingFileByLine(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);
            int i = 0;
            foreach (var line in lines)
            {
                Console.WriteLine($"{i++}.{line}");
            }
        }

        //逐行读取，无需等待所有行都读取完
        public static void ReadingFileLineByLine(string fileName)
        {
            IEnumerable<string> lines =  File.ReadLines(fileName);
            int i = 0;
            foreach (var line in lines)
            {
                Console.WriteLine($"{i++}.{line}");
            }
        }
    }
}
