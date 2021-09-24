using System;

namespace FileManager
{
    internal class Help
    {
        public static void Show()
        {
            Console.WriteLine("\t\t\t--Command list--");
            Console.WriteLine("1.cd - shows directories and files in a directory\n  Arguments: target directory\n  Example: cd D:\\directory\\");
            Console.WriteLine("2.cdp - shows directories and files in a directory with paging\n  Arguments: page number, target directory\n  Example: cdp 2 D:\\directory\\");
            Console.WriteLine("3.cdhome - shows available drives");
            Console.WriteLine("4.dirinfo - show directory properties\n  Arguments: directory\n  Example: dirinfo D:\\directory\\");
            Console.WriteLine("5.dircopy - copies a directory and subdirectories to a new directory\n  Arguments: source directory, target directory\n  Example: dircopy D:\\sourcdirectory\\ D:\\targetdyrectory\\");
            Console.WriteLine("6.dirdel - removes the directory and all attachments\n  Arguments: directory\n  Example: dirdel D:\\directory\\");
            Console.WriteLine("7.fileinfo - show file properties\n  Arguments: file\n  Example: fileinfo D:\\file.txt");
            Console.WriteLine("8.filecopy - copies a file to a new directory\n  Arguments: source file, target directory\n  Example: filecopy D:\\file.txt D:\\targetdyrectory\\");
            Console.WriteLine("9.filedel - removes the file\n  Arguments: file\n  Example: filedel D:\\file.txt");
            Console.WriteLine("10.help - shows available commands");
            Console.WriteLine("11.exit - exit the program");
        }
    }
}