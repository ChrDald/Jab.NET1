using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadWriteFile
{
    class Program
    {
        public static List<String> AppendingLines = new List<string>();

        static void Main(string[] args)
        {
            // Reading from file
            // first surround with try/catch
            try
            {
                // save the lines (for example) in a String[] array
                // (import System.IO to use File)
                String[] fileLines = File.ReadAllLines(@"people.txt");
                // the @ in the parameter means you wont need escape characters for the link

                foreach (String lines in fileLines)
                {
                    // Do what you need to do with each individual line
                    Console.WriteLine("Reading file...");

                    // if you need to split the lines, use this for example
                    // String[] SplitLines = lines.Split(':'); // has to be SINGLE quotes here (google why)

                    AppendingLines.Add(lines);
                    
                }
                // Write to the file using streamwriter
                
                foreach (String lines in AppendingLines)
                {
                    // if you use WriteAllText instead of Append, everytime write is called it deletes previous content
                    File.AppendAllText(@"people.txt", "\n" + lines + " -> line added");
                    Console.WriteLine("Line Added...");
                }
                

            } catch (IOException) // not sure if this is ok or if youd want a specific exception, readAllLines can throw
            {
                Console.WriteLine("IO Exception, please try again...");
                Console.ReadLine();
            }
            Console.ReadLine();
        }
    }
}
