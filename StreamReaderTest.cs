using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StreamTest
{
    public static class StreamReaderTest
    {
        public static void ReadTextUsingStreamRead()
        {
            string pathSource = @"..\..\..\source.txt";
            string pathNew = @"..\..\..\newfile.txt";
            string str;
            using (var stream = File.OpenRead(pathSource))
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);//默认编码方式指定为UTF-8
                str=reader.ReadToEnd();
            }
            Console.WriteLine(str);
            using (StreamWriter writer = new StreamWriter(pathNew, true, Encoding.UTF8))
            {
                writer.Write(str);
            }
        }
    }
}
