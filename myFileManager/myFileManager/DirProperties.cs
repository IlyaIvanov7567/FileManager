using System;
using System.IO;

namespace FileManager
{
    internal class DirProperties
    {
        public static void Show(string path)
        {
            if (Directory.Exists(path))
            {
                DirectoryInfo di = new DirectoryInfo(path);
                DirectoryInfo[] dirs = di.GetDirectories();
                FileInfo[] files = di.GetFiles();
                DateTime dtCreated = di.CreationTime;
                DateTime dtModified = di.LastWriteTime;
                FileAttributes attributes = File.GetAttributes(path);
                long dirsize = DirSize(di);

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\n\t\t\t--Info--");
                Console.ResetColor();
                Console.WriteLine("Name: \t\t{0}", di.Name);
                Console.WriteLine("Path: \t\t{0}", di.FullName);
                Console.WriteLine("Size: \t\t{0} byte", dirsize);
                Console.WriteLine("Contain: \tFiles:{0} Folders:{1}", files.Length, dirs.Length);
                Console.WriteLine("Created: \t{0}", dtCreated.ToString());
                Console.WriteLine("Modified: \t{0}", dtModified.ToString());
                Console.WriteLine("Attributes: \t{0}", attributes);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Directory {0} not found", path);
                Console.ResetColor();
            }
        }

        public static long DirSize(DirectoryInfo path)
        {
            long size = 0;

            // Count file sizes
            try
            {
                FileInfo[] filess = path.GetFiles();
                foreach (FileInfo file in filess)
                {
                    size += file.Length;
                }
            }

            // Inform and log exception
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(e.Message);
                Console.ResetColor();

                string log = $"\n{DateTime.Now} {e.Message}\n{e.StackTrace}";
                File.AppendAllText($"{Directory.GetCurrentDirectory()}\\error\\log.txt", log);
            }

            // Count subdirectory sizes
            try
            {
                DirectoryInfo[] dirs = path.GetDirectories();
                foreach (DirectoryInfo dir in dirs)
                {
                    size += DirSize(dir);
                }
            }

            // Inform and log exception
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(e.Message);
                Console.ResetColor();
                
                string log = $"\n{DateTime.Now} {e.Message}\n{e.StackTrace}";
                File.AppendAllText($"{Directory.GetCurrentDirectory()}\\error\\log.txt", log);
            }
            return size;
        }
    }
}