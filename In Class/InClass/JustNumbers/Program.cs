using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustNumbers
{
    class Program
    {
        static List<int> integers = new List<int>();

        static void Main(string[] args)
        {
            bool done = false;
            double avg;
            int max;
            double med = 0;

            while (!done)
            {
                Console.WriteLine("Enter a positive integer number, to quit, enter a negative value");
                String strUserInput = Console.ReadLine();
                int intUserInput;

                try
                {
                    intUserInput = Int32.Parse(strUserInput);

                } catch (Exception)
                {
                    Console.WriteLine("Invalid number value entered, must be an integer");
                    continue;
                }
                
                if (intUserInput == 0)
                {
                    Console.WriteLine("0 entered, calculating...");

                    avg = integers.Average();
                    max = integers.Max();
                    integers.Sort();

                    if (integers.Count % 2 == 0) 
                    {
                        // figure this out
         
                    }
                    else
                    {
                        int MedIndex = integers.Count / 2 + 1;
                        med = integers[MedIndex];
                    }   
                    
                    Console.WriteLine("Average: " + avg);
                    Console.WriteLine("Max: " + max);
                    Console.WriteLine("Median: " + med);
                    done = true;
                    Console.ReadLine();
                }
                else
                {
                    integers.Add(intUserInput);
                    Console.WriteLine(integers.Count);
                    continue;
                }
            }
            
        }
    }
}
