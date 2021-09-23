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
                    Console.WriteLine("Directory {0} deleted", path);
                }

                // Inform and log exception
                catch (Exception e)
                {
                    Console.Write(e.Message);

                    string log = $"\n{DateTime.Now} Msg: {e.Message}File: {path}\n{e.StackTrace}";
                    File.AppendAllText($"{Directory.GetCurrentDirectory()}\\error\\log.txt", log);
                    return;
                }
            }

            // Inform, that the directory does not exist
            else
            {
                Console.WriteLine("Directroy not found");
            }
        }
    }
}