using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexerPrimes
{
    class PrimeArray
    {
        public bool isPrime(int number)
        {
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0 && i != number) return false;
            }
            return true;
        }

        // indexer use
        public bool this[int number]
        {
            get
            {
                for (int i = 2; i < number; i++)
                {
                    if (number % i == 0 && i != number) return false;
                }
                return true;
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            PrimeArray pa = new PrimeArray();

            for (int value = 1; value < 15; value++) {
                Console.WriteLine("Value {0} is prime: {1}", value, pa[value]);
            }

            Console.ReadLine();
        }
    }
}
