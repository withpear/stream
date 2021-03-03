using System;
using System.IO;
using System.Linq;

namespace StreamTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //FileSystemInfoTest.ThroughFilesAndDirs();
            //FileInfoTest.CreateFile();
            //FileInfoTest.FileInfomation(@"..\..\..\Program.cs");

            //FileTest.CreateFile();

            //DirectoryTest.EnumerateFiles();
            //DirectoryTest.MoveFiles();

            //FileStreamTest.ReadFileUsingFileStream(@"..\..\..\Program.cs");
            //FileStreamTest.WriteFileUsingFileStream();

            //FileStreamRead.ReadAndWriteUsingFileStream();

            //StreamReaderTest.ReadTextUsingStreamRead();

            BinaryReaderTest.ReadClassUsingBinaryReader();
            Console.WriteLine("Hello World!");
        }


    }
}
