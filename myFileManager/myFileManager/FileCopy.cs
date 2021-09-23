using System;
using System.IO;

namespace FileManager
{
    internal class FileCopy
    {
        public static void Copy(string sourceFile, string targetDir)
        {
            FileInfo fi = new FileInfo(sourceFile);
            DirectoryInfo di = new DirectoryInfo(targetDir);
            var path = Path.Combine(targetDir, fi.Name);

            // Check the source file exist
            if (fi.Exists)
            {
                // Check the target file exist
                if (File.Exists(path))
                {
                    // Rewrite request
                    Console.WriteLine("Target file already exist. Overwrite (y\\y)?");
                    var answer = Console.ReadLine();

                    // Copy file to target directory with overwrite and inform
                    if (answer == "y")
                    {
                        // Check if the target directory exists, if not, create it
                        if (Directory.Exists(di.FullName) == false)
                        {
                            Directory.CreateDirectory(di.FullName);
                        }

                        // Try to copy file
                        try
                        {
                            fi.CopyTo(path, true);
                            Console.WriteLine(@"File {0} overwritten at {1}", fi.Name, di.FullName);
                        }

                        // Inform and log exception
                        catch (Exception e)
                        {
                            Console.Write(e.Message);

                            string log = $"\n{DateTime.Now} {e.Message}sourceFile: {sourceFile} targetDir: {targetDir}\n{e.StackTrace}";
                            File.AppendAllText($"{Directory.GetCurrentDirectory()}\\error\\log.txt", log);
                        }
                    }

                    // Copy canceled or wrong answer to the rewrite request
                    else
                    {
                        Console.WriteLine("Copy canceled");
                    }
                }
                else
                {
                    // Check if the target directory exists, if not, create it
                    if (Directory.Exists(di.FullName) == false)
                    {
                        Directory.CreateDirectory(di.FullName);
                    }

                    // Try to copy file
                    try
                    {
                        fi.CopyTo(path, true);
                        Console.WriteLine(@"File {0} copied to {1}", fi.Name, di.FullName);
                    }

                    // Inform and log exception
                    catch (Exception e)
                    {
                        Console.Write(e.Message);

                        string log = $"\n{DateTime.Now} {e.Message}sourceFile: {sourceFile} targetDir: {targetDir}\n{e.StackTrace}";
                        File.AppendAllText($"{Directory.GetCurrentDirectory()}\\error\\log.txt", log);
                    }
                }
            }

            // Inform, that the file does not exist
            else
            {
                Console.WriteLine("File not found");
            }
        }
    }
}