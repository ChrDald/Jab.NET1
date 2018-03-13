using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void PrintSimple(String line)
        {
            Console.WriteLine("SIMPLE: " + line);
        }

        static void PrintFancy(String line)
        {
            Console.WriteLine("!!!!!!!!!!!!!!!! {0} !!!!!!!!!!!!!!!!!!!! {1}", line, line.Length);
        }

        static void PrintToFile(String line)
        {
            File.AppendAllText("output.txt", line + "\n");
        }

        delegate void PrinterMethodType(String str);    // first you declare the delegate TYPE (Refer to the signature (return and parameter) of the methods
                                                        // THIS IS NOT A METHOD NAME, ITS A TYPE

        static void Main(string[] args)
        {
            PrinterMethodType printer = null;   // initialize the delegate
            printer = PrintSimple;  // Youre assigning the name of the method to the "instance" of your delegate called printer, IE youre saving the REFERENCE to the METHOD in the variable
            printer += PrintFancy;  // You can assign multiple pointers to the variable(delegate), so basically you call multiple methods at once
            printer += PrintToFile; // when you use += , you ADD a pointer to the existing list, if you only write printer = (method), then the previous list will be nonexistant
            printer -= PrintToFile; // you can also remove a specific pointer using -=
            printer("A delegate");  // this is how you call the method with the delegate
            Console.ReadLine();
        }
    }
}
