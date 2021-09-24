using System;
using System.IO;

namespace FileManager
{
    internal class StartUp
    {
        public static void Start()
        {

            string[] arr = Properties.Settings.Default.LastDir.Split();

            // Check if the error folder exists, if not, create it
            if (Directory.Exists($"{Directory.GetCurrentDirectory()}\\error") == false)
            {
                Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}\\error");
            }

            // If the last directory exist, try to show it
            if (arr[0] == "cd" && arr.Length == 2 && Directory.Exists(arr[1]))
            {
                ChangeDir.Show(arr[1]);

            }
            else if (arr[0] == "cdp" && arr[1] != null && arr.Length == 3 && Directory.Exists(arr[2]))
            {
                var page = Byte.Parse(arr[1]);
                ChangeDirPaging.Show(arr[2], page);
            }

            // If the last directory is broken or not exist show home page    
            else
            {
                HomePage.Home();
            }

            //Console.WriteLine("\nType help to see a list of available commands");
            MenuBar.Show();
        }
    }
}