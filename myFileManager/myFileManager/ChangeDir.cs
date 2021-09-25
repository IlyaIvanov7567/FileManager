using System;
using System.IO;

namespace FileManager
{
    internal class ChangeDir
    {
        public static void Show(string path)
        {

            DirectoryInfo di = new DirectoryInfo(path);
            DirectoryInfo[] dirs = di.GetDirectories();

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\t\t\t--Directory: {0}--", di.FullName);
            Console.ResetColor();

            // Output all directories
            foreach (var dir in dirs)
            {
                Console.WriteLine(dir);
            }

            // Output all files
            foreach (var file in di.GetFiles())
            {
                Console.WriteLine(file.Name);
            }
            MenuBar.Show();

        }
    }
}