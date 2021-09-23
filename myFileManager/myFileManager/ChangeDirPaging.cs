using System;
using System.IO;
using System.Linq;

namespace FileManager
{
    internal class ChangeDirPaging
    {
        public static void Show(string path, byte page)
        {
            var pageitem = Properties.Settings.Default.ItemPerPage;

            // Check the directory exist
            if (Directory.Exists(path))
            {
                DirectoryInfo di = new DirectoryInfo(path);

                // Get all element in directory
                var list = di.EnumerateFileSystemInfos();
                var listcount = list.Count<FileSystemInfo>();

                Console.Clear();
                Console.WriteLine("\t\t\t--Directory: {0}--", di.FullName);

                int i = 0;
                int firstitem = i + (pageitem * (page - 1));
               
                // Output element
                while (i < pageitem && firstitem < listcount)
                {
                    Console.WriteLine(list.ElementAt<FileSystemInfo>(firstitem));
                    i++;
                    firstitem++;
                }
                if (listcount < firstitem)
                {
                    Console.WriteLine("Empty page");
                }
                Console.WriteLine("\t--Page: {0}; Items per page: {1}; Total items: {2}--", page, pageitem, listcount);
            }

            // Inform, that the directory does not exist
            else
            {
                Console.WriteLine("Non-existent directory");
            }
        }
    }
}