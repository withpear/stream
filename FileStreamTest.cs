using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StreamTest
{
    public static class FileStreamTest
    {
        public static void ReadFileUsingFileStream(string fileName)
        {
            byte[] byteData = new byte[200];
            char[] charData = new char[200];
            try
            {
                FileStream fileStream = new FileStream(fileName, FileMode.Open);
                fileStream.Seek(0, SeekOrigin.Begin);
                fileStream.Read(byteData, 0, byteData.Length);
            }
            catch (IOException e)
            {
                throw e;
            }

            Decoder d = Encoding.UTF8.GetDecoder();
            d.GetChars(byteData, 0, byteData.Length, charData, 0);
            string str = new string(charData);

            //foreach (char c in charData)
            //{
            //    Console.Write("[{0}]", c);
            //}
            Console.WriteLine(str);
        }

        private static void ShowStreamInformation(Stream stream)
        {
            Console.WriteLine($"Steam can read: {stream.CanRead}");
            Console.WriteLine($"Steam can write: {stream.CanWrite}");
            Console.WriteLine($"Steam can seek: {stream.CanSeek}");
            Console.WriteLine($"Length: {stream.Length}");
            Console.WriteLine($"Position: {stream.Position}");
            if (stream.CanTimeout)
            {
                Console.WriteLine($"Read Timeout: {stream.ReadTimeout}"); //ReadTimeout,WriteTimeout指定超时，以毫秒为单位
                Console.WriteLine($"Write Timeout: {stream.WriteTimeout}");
            }
        }

        public static void WriteFileUsingFileStream()
        {
            byte[] byteData;
            char[] charData;
            try
            {
                FileStream fileStream = new FileStream("Temp.txt", FileMode.OpenOrCreate);
                charData = "My pink half of the drainpipe.".ToCharArray();
                byteData = new byte[charData.Length];
                Encoder encoder = Encoding.UTF8.GetEncoder();
                encoder.GetBytes(charData, 0, charData.Length, byteData, 0, true);
                fileStream.Seek(0, SeekOrigin.Begin);
                fileStream.Write(byteData, 0, byteData.Length);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
