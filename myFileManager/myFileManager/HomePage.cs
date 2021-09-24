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
            Console.WriteLine("\t\t\t--Directory: root--");

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