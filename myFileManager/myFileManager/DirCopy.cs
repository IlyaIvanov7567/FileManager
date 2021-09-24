using System;
using System.IO;

namespace FileManager
{
    internal class DirCopy
    {
        public static void Copy(DirectoryInfo source, DirectoryInfo target)
        {

            // Check if the source folder is the same that target folder
            if (source.FullName.ToLower() == target.FullName.ToLower())
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Folder {0} cannot be copied to folder {1}", source.FullName, target.FullName);
                Console.ResetColor();
                return;
            }

            // Check the source directory exists
            if (Directory.Exists(source.FullName) == false)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Non-existent source directory: {0}", source.FullName);
                Console.ResetColor();
                return;
            }

            DirectoryInfo[] subdis = source.GetDirectories();

            // If the target directory doesn't exist, create it       
            Directory.CreateDirectory(target.FullName);

            // Copy each file into it's new directory
            FileInfo[] fis = source.GetFiles();
            foreach (FileInfo fi in fis)
            {
                // Try to copy file
                try
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(@"Copied file {0} to {1}", fi.Name, target);
                    Console.ResetColor();
                    fi.CopyTo(Path.Combine(target.ToString(), fi.Name), true);
                }

                // Inform and log exception
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(e.Message);
                    Console.ResetColor();

                    string log = $"\n{DateTime.Now} {e.Message}sourceDir: {source} targetDir: {target} file: {fi.Name}\n{e.StackTrace}";
                    File.AppendAllText($"{Directory.GetCurrentDirectory()}\\error\\log.txt", log);
                }
            }

            // Copy each subdirectory using recursion
            foreach (DirectoryInfo subdi in subdis)
            {
                // Try to copy subdirectory
                try
                {
                    string tempPath = Path.Combine(target.FullName, subdi.Name);
                    Copy(subdi, new DirectoryInfo(tempPath));
                }

                // Inform and log exception
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(e.Message);
                    Console.ResetColor();

                    string log = $"\n{DateTime.Now} {e.Message}sourceDir: {source} targetDir: {target} subDir: {subdi}\n{e.StackTrace}";
                    File.AppendAllText($"{Directory.GetCurrentDirectory()}\\error\\log.txt", log);
                }
            }
        }
    }
}