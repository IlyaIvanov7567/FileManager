using System;
using System.IO;

namespace FileManager
{
    internal class FileProperties
    {
        public static void Show(string file)
        {
            if (File.Exists(file))
            {
                FileInfo fi = new FileInfo(file);
                DateTime dtCreated = fi.CreationTime;
                DateTime dtModified = fi.LastWriteTime;
                FileAttributes attributes = File.GetAttributes(file);
                
                Console.WriteLine("Name: \t\t{0}", fi.Name);
                Console.WriteLine("Extension: \t{0}", fi.Extension);
                Console.WriteLine("Path: \t\t{0}", fi.DirectoryName);
                Console.WriteLine("Size: \t\t{0} byte", fi.Length.ToString());
                Console.WriteLine("Created: \t{0}", dtCreated.ToString());
                Console.WriteLine("Modified: \t{0}", dtModified.ToString());
                Console.WriteLine("Read only: \t{0}", fi.IsReadOnly);
                Console.WriteLine("Attributes: \t{0}", attributes);
            }
            else
            {
                Console.WriteLine("File not found");
            }
        }
    }
}