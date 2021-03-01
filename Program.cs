using System;
using System.IO;
using System.Linq;

namespace Stream
{
    class Program
    {
        static void Main(string[] args)
        {
            FileSystemInfoTest.ThroughFilesAndDirs();
            FileInfoTest.CreateFile();
            FileInfoTest.FileInfomation(@"..\..\..\Program.cs");

            FileTest.CreateFile();


            DirectoryTest.EnumerateFiles();
            DirectoryTest.MoveFiles();

            Console.WriteLine("Hello World!");
        }


    }
}
