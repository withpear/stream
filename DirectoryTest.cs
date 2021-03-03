using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace StreamTest
{
    public static class DirectoryTest
    {
        public static void MoveFiles()
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

        public static void EnumerateFiles()
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
