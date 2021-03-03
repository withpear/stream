using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SteamTest
{
    public static class FileStreamRead
    {
        public static void ReadAndWriteUsingFileStream()
        {
            string pathSource = @"..\..\..\source.txt";
            string pathNew = @"..\..\..\newfile.txt";
            try
            {
                byte[] bytes = new byte[1024];
                using (var stream = new FileStream(pathSource, FileMode.Open, FileAccess.Read))
                {
                    int bytesRead;
                    do
                    {
                        bytesRead = stream.Read(bytes, 0, bytes.Length);
                    } while (bytesRead > 0);
                }

                using (var stream = new FileStream(pathNew, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    stream.Write(bytes, 0, bytes.Length);
                }
            }
            catch (IOException ioEx)
            {
                Console.WriteLine(ioEx.Message);
            }
        }
    }
}
