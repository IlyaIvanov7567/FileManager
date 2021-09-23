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
                    Console.WriteLine("Fle {0} deleted", file);
                }

                // Inform and log exception
                catch (Exception e)
                {
                    Console.Write(e.Message);

                    string log = $"\n{DateTime.Now} Msg: {e.Message}File: {file}\n{e.StackTrace}";
                    File.AppendAllText("log.txt", log);
                    return;
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