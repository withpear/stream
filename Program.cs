using System;
using System.IO;
using System.Linq;

namespace Stream
{
    class Program
    {
        static void Main(string[] args)
        {
            FileTest();
            FileInfoTest();
            DirectoryTest();
            EnumerateFiles();
            Console.WriteLine("Hello World!");
        }

        static void FileTest()
        {
            var path = "MyTest.txt";
            if (!File.Exists(path))
            {
                using(StreamWriter stream = File.CreateText(path))
                {
                    stream.WriteLine("Hello");
                    stream.WriteLine("CSharp");
                }
            }

            using(StreamReader stream = File.OpenText(path))
            {
                string s;
                while ((s = stream.ReadLine()) != null){
                    Console.WriteLine(s);
                }
            }
        }

        static void FileInfoTest()
        {
            string path = Path.GetTempFileName();//创建临时文件
            var fileInfo = new FileInfo(path);
            using(StreamWriter sw = fileInfo.CreateText())
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

        static void DirectoryTest()
        {
            string sourceDir = "current";
            string archiveDir = "archive";
            if (!Directory.Exists(sourceDir))
            {
                Directory.CreateDirectory(sourceDir);
            }
            if (!Directory.Exists(archiveDir))
            {
                Directory.CreateDirectory(archiveDir);
            }
            try
            {
                var txtFiles = Directory.EnumerateFiles(sourceDir, "*.txt");
                foreach (var file in txtFiles)
                {
                    string fileName = file.Substring(sourceDir.Length + 1);
                    Directory.Move(file, Path.Combine(archiveDir, fileName));//移动文件到新文件夹
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void EnumerateFiles()
        {
            string archiveDir = "archive";
            var files = from retrievedFile in Directory.EnumerateFiles(archiveDir, "*.txt", SearchOption.AllDirectories)
                        from line in File.ReadLines(retrievedFile)
                        where line.Contains("Example")
                        select new
                        {
                            File = retrievedFile,
                            Line = line
                        };

            foreach (var f in files)
            {
                Console.WriteLine("{0} constains {1}", f.File, f.Line);
            }
            Console.WriteLine("{0} lines found.", files.Count().ToString());
        }
    }
}
