using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            String10Storage StringsIndex = new String10Storage();

            StringsIndex[9] = "Some Value";
            StringsIndex[3] = "Another Value";
            StringsIndex[5] = "Any Value";
            StringsIndex[0] = "Not exactly sure how this works and why we use it...";
            Console.WriteLine("\nIndexer Output\n");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("StringsIndex[{0}]: {1}", i, StringsIndex[i]);
            }
            Console.ReadKey();
        }
    }

    class String10Storage
    {
        private String[] MyStrings = new String[10];

        public String10Storage()
        {
            MyStrings = new string[10];

            for (int i = 0; i < 10; i++)
            {
                MyStrings[i] = "empty";
            }
        }

        // Getters and Setters to manipulate the array's data
        public string this[int pos]
        {
            get
            {
                return MyStrings[pos];
            }
            set
            {
                MyStrings[pos] = value;
            }
        }
    }
}
