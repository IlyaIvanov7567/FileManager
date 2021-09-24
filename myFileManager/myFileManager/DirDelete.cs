using System;
using System.IO;

namespace FileManager
{
    internal class DirDelete
    {
        public static void Delete(string path)
        {
            // Check the directory exist
            if (Directory.Exists(path))
            {
                // Try to delete directory
                try
                {
                    Directory.Delete(path, true);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Deleted directory {0}", path);
                    Console.ResetColor();
                }

                // Inform and log exception
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(e.Message);
                    Console.ResetColor();

                    string log = $"\n{DateTime.Now} Msg: {e.Message}File: {path}\n{e.StackTrace}";
                    File.AppendAllText($"{Directory.GetCurrentDirectory()}\\error\\log.txt", log);
                    return;
                }
            }

            // Inform, that the directory does not exist
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Directroy {0} not found", path);
                Console.ResetColor();
            }
        }
    }
}