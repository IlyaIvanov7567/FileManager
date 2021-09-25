using System;
using System.IO;

namespace FileManager
{
    internal class FileDelete
    {
        public static void Delete(string file)
        {
            FileInfo fi = new FileInfo(file);

            // Check the file exist
            if (fi.Exists)
            {
                // Try to delete file
                try
                {
                    File.Delete(file);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Fle {0} deleted", file);
                    Console.ResetColor();
                }

                // Inform and log exception
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(e.Message);
                    Console.ResetColor();

                    string log = $"\n{DateTime.Now} Msg: {e.Message}File: {file}\n{e.StackTrace}";
                    File.AppendAllText("log.txt", log);
                    return;
                }
            }

            // Inform, that the file does not exist
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("File {0} not found", file);
                Console.ResetColor();
            }
        }
    }
}