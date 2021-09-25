using System;

namespace FileManager
{
    internal class Help
    {
        public static void Show()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\t\t\t--Command list--");
            Console.ResetColor();
            Console.WriteLine("cd\nDescription: shows directories and files in a directory\nArguments: target directory\nExample: cd D:\\directory\\");
            Console.WriteLine("----");
            Console.WriteLine("cdp\nDescription: shows directories and files in a directory with paging\nArguments: page number, target directory\nExample: cdp 2 D:\\directory\\");
            Console.WriteLine("----");
            Console.WriteLine("cdhome\nDescription: shows available drives");
            Console.WriteLine("----");
            Console.WriteLine("dirinfo\nDescription: show directory properties\nArguments: directory\nExample: dirinfo D:\\directory\\");
            Console.WriteLine("----");
            Console.WriteLine("dircopy\nDescription: copies a directory and subdirectories to a new directory\nArguments: source directory, target directory\nExample: dircopy D:\\sourcdirectory\\ D:\\targetdyrectory\\");
            Console.WriteLine("----");
            Console.WriteLine("dirdel\nDescription: removes the directory and all attachments\nArguments: directory\nExample: dirdel D:\\directory\\");
            Console.WriteLine("----");
            Console.WriteLine("fileinfo\nDescription: show file properties\nArguments: file\nExample: fileinfo D:\\file.txt");
            Console.WriteLine("----");
            Console.WriteLine("filecopy\nDescription: copies a file to a new directory\nArguments: source file, target directory\nExample: filecopy D:\\file.txt D:\\targetdyrectory\\");
            Console.WriteLine("----");
            Console.WriteLine("filedel\nDescription: removes the file\nArguments: file\nExample: filedel D:\\file.txt");
            Console.WriteLine("----");
            Console.WriteLine("help\nDescription: shows available commands");
            Console.WriteLine("----");
            Console.WriteLine("exit\nDescription: exit the program");
        }
    }
}