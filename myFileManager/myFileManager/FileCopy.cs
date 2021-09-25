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
                // Check if a file with source file name exists
                if (File.Exists(path))
                {
                    // Rewrite request
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("File {0} file already exist. Overwrite (y\\n)?", path);
                    Console.ResetColor();
                    var answer = Console.ReadLine();

                    // Copy file to target directory with overwrite and inform
                    if (answer == "y")
                    {
                        // Check the target directory exists, if not, create it
                        if (Directory.Exists(di.FullName) == false)
                        {
                            Directory.CreateDirectory(di.FullName);
                        }

                        // Try to copy file
                        try
                        {
                            fi.CopyTo(path, true);
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine(@"File {0} overwritten at {1}", fi.Name, di.FullName);
                            Console.ResetColor();
                        }

                        // Inform and log exception
                        catch (Exception e)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write(e.Message);
                            Console.ResetColor();

                            string log = $"\n{DateTime.Now} {e.Message}sourceFile: {sourceFile} targetDir: {targetDir}\n{e.StackTrace}";
                            File.AppendAllText($"{Directory.GetCurrentDirectory()}\\error\\log.txt", log);
                        }
                    }

                    // Copy canceled or wrong answer to the rewrite request
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Copy canceled");
                        Console.ResetColor();
                    }
                }
                
                //If a file with source file name dosen`t exists
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
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine(@"File {0} copied to {1}", fi.Name, di.FullName);
                        Console.ResetColor();
                    }

                    // Inform and log exception
                    catch (Exception e)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(e.Message);
                        Console.ResetColor();

                        string log = $"\n{DateTime.Now} {e.Message}sourceFile: {sourceFile} targetDir: {targetDir}\n{e.StackTrace}";
                        File.AppendAllText($"{Directory.GetCurrentDirectory()}\\error\\log.txt", log);
                    }
                }
            }

            // Inform, that thec source file does not exist
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("File {0} not found", sourceFile);
                Console.ResetColor();
            }
        }
    }
}