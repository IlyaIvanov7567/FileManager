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

            // Check the source directory exists. If not, return
            if (Directory.Exists(source.FullName) == false)
            {
                Console.WriteLine("Non-existent source directory");
                return;
            }

            DirectoryInfo[] subdis = source.GetDirectories();

            // If the destination directory doesn't exist, create it.       
            Directory.CreateDirectory(target.FullName);

            // Copy each file into it's new directory
            FileInfo[] fis = source.GetFiles();
            foreach (FileInfo fi in fis)
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
            
            foreach (DirectoryInfo subdi in subdis)
            {
                // Try to copy subdirectory
                try
                {
                    string tempPath = Path.Combine(target.FullName, subdi.Name);
                    //DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(di.Name);
                    Copy(subdi, new DirectoryInfo(tempPath));
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