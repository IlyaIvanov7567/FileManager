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
                Console.WriteLine("Folder {0} cannot be copied to folder {1}", source.FullName, target.FullName);
                return;
            }

            // Check if the source directory exists, if not, return
            if (Directory.Exists(source.FullName) == false)
            {
                Console.WriteLine("Non-existent source directory");
                return;
            }

            // Check if the target directory exists, if not, create it
            if (Directory.Exists(target.FullName) == false)
            {
                Directory.CreateDirectory(target.FullName);
            }

            // Copy each file into it's new directory
            foreach (FileInfo fi in source.GetFiles())
            {
                // Try to copy file
                try
                {
                    Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                    fi.CopyTo(Path.Combine(target.ToString(), fi.Name), true);
                }

                // Inform and log exception
                catch (Exception e)
                {
                    Console.Write(e.Message);

                    string log = $"\n{DateTime.Now} {e.Message}sourceFile: {source} targetDir: {target}\n{e.StackTrace}";
                    File.AppendAllText($"{Directory.GetCurrentDirectory()}\\error\\log.txt", log);
                }
            }

            // Copy each subdirectory using recursion
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                // Try to copy subdirectory
                try
                {
                    DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);
                    Copy(diSourceSubDir, nextTargetSubDir);
                }

                // Inform and log exception
                catch (Exception e)
                {
                    Console.Write(e.Message);

                    string log = $"\n{DateTime.Now} {e.Message}sourceFile: {source} targetDir: {target}\n{e.StackTrace}";
                    File.AppendAllText($"{Directory.GetCurrentDirectory()}\\error\\log.txt", log);
                }
            }
        }
    }
}