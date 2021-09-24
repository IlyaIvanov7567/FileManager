using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    class MenuBar
    {
        public static void Show()
        {
            Console.WriteLine("\n+----------------------------------------------------------------------------------------------+");
            Console.WriteLine("| cd | cdp | cdhome | dirinfo | dircopy | dirdel | fileinfo | filecopy | filedel | exit | help |");
            Console.WriteLine("+----------------------------------------------------------------------------------------------+");
        }
    }
}
