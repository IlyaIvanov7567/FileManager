using System;
using System.IO;

namespace FileManager
{
    internal class HomePage
    {
        public static void Home()
        {
            string[] drives = Directory.GetLogicalDrives();

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\t\t\t--Directory: root--");
            Console.ResetColor();

            // Show all drives
            foreach (var drive in drives)
            {
                Console.WriteLine(drive);
            }

            // Reset work directory
            Properties.Settings.Default.Reset();

            MenuBar.Show();
        }
    }
}