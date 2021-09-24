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
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Non-existent directory: {0}", arr[1]);
                        Console.ResetColor();
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

                        // Restor last work directory to cleanup console
                        // Inform, that the directory does not exist
                        else
                        {
                            StartUp.Start();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Wrong page. Available page 1..255.");
                            Console.ResetColor();
                        }
                    }

                    // Restor last work directory to cleanup console
                    // Inform, that the directory does not exist
                    else
                    {
                        StartUp.Start();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Non-existent directory: {0}", arr[2]);
                        Console.ResetColor();
                    }
                }

                // Restor last work directory to cleanup console
                // Copy directory
                else if (arr[0] == "dircopy" && arr.Length == 3)
                {
                    DirectoryInfo diSource = new DirectoryInfo(arr[1]);
                    DirectoryInfo diTarget = new DirectoryInfo(arr[2]);
                    StartUp.Start();
                    DirCopy.Copy(diSource, diTarget);
                }

                // Restor last work directory to cleanup console
                // Delete directory
                else if (arr[0] == "dirdel" && arr.Length == 2)
                {
                    StartUp.Start();
                    DirDelete.Delete(arr[1]);
                }

                // Restor last work directory to cleanup console
                // Directory properties
                else if (arr[0] == "dirinfo" && arr.Length == 2)
                {
                    StartUp.Start();
                    DirProperties.Show(arr[1]);
                }

                // Restor last work directory to cleanup console
                // Copy file
                else if (arr[0] == "filecopy" && arr.Length == 3)
                {
                    StartUp.Start();
                    FileCopy.Copy(arr[1], arr[2]);
                }

                // Restor last work directory to cleanup console
                // Delete file
                else if (arr[0] == "filedel" && arr.Length == 2)
                {
                    StartUp.Start();
                    FileDelete.Delete(arr[1]);
                }

                // Restor last work directory to cleanup console
                // File properties
                else if (arr[0] == "fileinfo" && arr.Length == 2)
                {
                    StartUp.Start();
                    FileProperties.Show(arr[1]);
                }

                // Restor last work directory to cleanup console
                // Show Help
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

                // Restor last work directory to cleanup console
                // Inform Unsupported commands
                else
                {
                    StartUp.Start();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Invalid command. Type help for more info.");
                    Console.ResetColor();
                }
            }
        }
    }
}