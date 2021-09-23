using System;
using System.IO;

namespace FileManager
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            StartUp.Start();

            while (true)
            {
                string input = Console.ReadLine();
                string[] arr = input.Split();

                // Home page
                if (arr[0] == "cdhome" && arr.Length == 1)
                {
                    HomePage.Home();
                }

                // Change directory
                else if (arr[0] == "cd" && arr.Length == 2)
                {
                    Properties.Settings.Default.LastDir = input;
                    Properties.Settings.Default.Save();
                    ChangeDir.Show(arr[1]);
                }

                // Change directory with paging
                else if (arr[0] == "cdp" && arr[1] != null && arr.Length == 3)
                {
                    bool isnumber = Byte.TryParse(arr[1], out byte page);
                    if (isnumber)
                    {
                        Properties.Settings.Default.LastDir = input;
                        Properties.Settings.Default.Save();
                        ChangeDirPaging.Show(arr[2], page);
                    }
                    else
                    {
                        Console.WriteLine("Wrong page");
                    }
                }

                // Copy directory
                else if (arr[0] == "dircopy" && arr.Length == 3)
                {
                    DirectoryInfo diSource = new DirectoryInfo(arr[1]);
                    DirectoryInfo diTarget = new DirectoryInfo(arr[2]);
                    DirCopy.Copy(diSource, diTarget);
                }

                // Delete directory
                else if (arr[0] == "dirdel" && arr.Length == 2)
                {
                    DirDelete.Delete(arr[1]);
                }

                // Directory properties
                else if (arr[0] == "dirinfo" && arr.Length == 2)
                {
                    DirProperties.Show(arr[1]);
                }

                // Copy file
                else if (arr[0] == "filecopy" && arr.Length == 3)
                {
                    FileCopy.Copy(arr[1], arr[2]);
                }

                // Delete file
                else if (arr[0] == "filedel" && arr.Length == 2)
                {
                    FileDelete.Delete(arr[1]);
                }

                // File properties
                else if (arr[0] == "fileinfo" && arr.Length == 2)
                {
                    FileProperties.Show(arr[1]);
                }

                // Help
                else if (arr[0] == "help" && arr.Length == 1)
                {
                    Help.Show();
                }

                //Exit
                else if (arr[0] == "exit" && arr.Length == 1)
                {
                    break;
                }

                // Unsupported commands. Restor last position
                else
                {
                    StartUp.Start();
                    Console.WriteLine("Invalid command.");
                }
            }
        }
    }
}