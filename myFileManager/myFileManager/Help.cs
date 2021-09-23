using System;

namespace FileManager
{
    internal class Help
    {
        public static void Show()
        {
            Console.WriteLine("\t\t\t--Command list--");
            Console.WriteLine("1.help - shows available commands");
            Console.WriteLine("2.cd - shows directories and files in a directory\nArguments: target directory\nExample: cd D:\\directory\\");
            Console.WriteLine("3.cdp - shows directories and files in a directory with paging\nArguments: page number, target directory\nExample: cdp 2 D:\\directory\\");
            Console.WriteLine("4.cdhome - shows available drives");
            Console.WriteLine("5.dirinfo - show directory properties\nArguments: directory\nExample: dirinfo D:\\directory\\");
            Console.WriteLine("6.dircopy - copies a directory and subdirectories to a new directory\nArguments: source directory, target directory\nExample: dircopy D:\\sourcdirectory\\ D:\\targetdyrectory\\");
            Console.WriteLine("7.dirdel - removes the directory and all attachments\nArguments: directory\nExample: dirdel D:\\directory\\");
            Console.WriteLine("8.fileinfo - show file properties\nArguments: file\nExample: fileinfo D:\\file.txt");
            Console.WriteLine("9.filecopy - copies a file to a new directory\nArguments: source file, target directory\nExample: filecopy D:\\file.txt D:\\targetdyrectory\\");
            Console.WriteLine("10.filedel - removes the file\nArguments: file\nExample: filedel D:\\file.txt");
            Console.WriteLine("11.exit - exit the program");
        }
    }
}