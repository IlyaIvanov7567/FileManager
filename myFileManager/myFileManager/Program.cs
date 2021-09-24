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
                    // Check the directory exists 
                    if (Directory.Exists(arr[1]))
                    {
                        // Save work directory
                        Properties.Settings.Default.LastDir = input;
                        Properties.Settings.Default.Save();

                        // Show directory attachment
                        ChangeDir.Show(arr[1]);
                    }

                    // Restor last work directory
                    // Inform, that the directory does not exist
                    else
                    {
                        StartUp.Start();
                        Console.WriteLine("Non-existent directory: {0}", arr[1]);
                    }
                }

                // Change directory with paging
                else if (arr[0] == "cdp" && arr.Length == 3)
                {
                    // Check the directory exists
                    if (Directory.Exists(arr[2]))
                    {
                        bool isnumber = Byte.TryParse(arr[1], out byte page);
                        if (isnumber && Byte.Parse(arr[1])>0)
                        {
                            // Save work directory
                            Properties.Settings.Default.LastDir = input;
                            Properties.Settings.Default.Save();

                            // Show directory attachment with paging
                            ChangeDirPaging.Show(arr[2], page);
                        }

                        // Restor last work directory
                        // Inform, that the directory does not exist
                        else
                        {
                            StartUp.Start();
                            Console.WriteLine("Wrong page. Available page 1..255.");
                        }
                    }

                    // Restor last work directory
                    // Inform, that the directory does not exist
                    else
                    {
                        StartUp.Start();
                        Console.WriteLine("Non-existent directory: {0}", arr[2]);
                    }
                }

                // Copy directory and restor last position to cleanup console
                else if (arr[0] == "dircopy" && arr.Length == 3)
                {
                    DirectoryInfo diSource = new DirectoryInfo(arr[1]);
                    DirectoryInfo diTarget = new DirectoryInfo(arr[2]);
                    StartUp.Start();
                    DirCopy.Copy(diSource, diTarget);
                }

                // Delete directory and restor last position to cleanup console
                else if (arr[0] == "dirdel" && arr.Length == 2)
                {
                    StartUp.Start();
                    DirDelete.Delete(arr[1]);
                }

                // Directory properties and restor last position to cleanup console
                else if (arr[0] == "dirinfo" && arr.Length == 2)
                {
                    StartUp.Start();
                    DirProperties.Show(arr[1]);
                }

                // Copy file and restor last position to cleanup console
                else if (arr[0] == "filecopy" && arr.Length == 3)
                {
                    StartUp.Start();
                    FileCopy.Copy(arr[1], arr[2]);
                }

                // Delete file and restor last position to cleanup console
                else if (arr[0] == "filedel" && arr.Length == 2)
                {
                    StartUp.Start();
                    FileDelete.Delete(arr[1]);
                }

                // File properties and restor last position to cleanup console
                else if (arr[0] == "fileinfo" && arr.Length == 2)
                {
                    StartUp.Start();
                    FileProperties.Show(arr[1]);
                }

                // Help and restor last position to cleanup console
                else if (arr[0] == "help" && arr.Length == 1)
                {
                    StartUp.Start();
                    Help.Show();
                }

                //Exit
                else if (arr[0] == "exit" && arr.Length == 1)
                {
                    break;
                }

                // Unsupported commands and restor last position to cleanup console
                else
                {
                    StartUp.Start();
                    Console.WriteLine("Invalid command. Type help for more info.");
                }
            }
        }
    }
}