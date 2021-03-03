using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StreamTest
{
    public static class FileSystemInfoTest
    {
        public static void ThroughFilesAndDirs()
        {
            string path = @"C:\";
            foreach (var entry in Directory.EnumerateDirectories(path))
            {
                DisplayFileSystemInfoAttributes(new DirectoryInfo(entry));
            }

            foreach (var entry in Directory.EnumerateFiles(path))
            {
                DisplayFileSystemInfoAttributes(new FileInfo(entry));
            }
        }

        static void DisplayFileSystemInfoAttributes(FileSystemInfo fsi)
        {
            string entryType = "File";
            if((fsi.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
            {
                entryType = "Directory";
            }
            Console.WriteLine("{0} entry {1} was created on {2:Y}", entryType, fsi.FullName, fsi.CreationTime);
        }
    }
}
