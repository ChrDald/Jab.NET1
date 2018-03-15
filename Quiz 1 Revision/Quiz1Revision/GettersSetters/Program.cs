using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GettersSetters
{
    class Person
    {
        private String _name;   // these variables are used to get/set data from
        private int _age;

        public Person(String name, int age)
        {
            _name = name;    // Name (capital N) calls the getters/setters for the Name string below, and name (lowercase) refers to the value passed to the constructor
            _age = age;
        }

        public String Name  // c# style getters and setters
                            // youre basically created a method that can be accesed like a variable (called Name)
                            // when you get the value of it, it calls the getter (that returns _name)
                            // when you set a value to it, it calls the setter
        {
            get
            {
                return _name;
            }
            set
            {
                // you can do whatever you want when getting and setting
                var regex = new Regex(@"(\D|\s){1,20}");    // supposed to be any character except digits, 1 to 20 characters long
                // verify the name has the right format
                if (!regex.IsMatch(value))
                {
                    throw new InvalidDataException("Invalid Name value...");
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person("CD", 12);
            String GetName = p.Name;    // p.Name calls the getter that fetches the _name data
            Console.WriteLine(GetName);
            Console.ReadKey();
        }
    }
}
