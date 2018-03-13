using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortEasy
{
    public class Person
    {
        public String Name;
        public int Age;

        public override string ToString()
        {
            return "Name: " + Name + " Age: " + Age;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> list = new List<Person>();

            list.Add(new Person() { Name = "Jerry", Age = 24 });    // shortcut to create a person object and add to list in same line
            list.Add(new Person() { Name = "Zerto", Age = 37 });
            list.Add(new Person() { Name = "Ay", Age = 49 });
            list.Add(new Person() { Name = "Shirley", Age = 20 });
            list.Add(new Person() { Name = "Dog", Age = 7 });

            foreach (Person p in list)
            {
                //Console.WriteLine(p.ToString());
                Console.WriteLine("{0}'s age is: {1}", p.Name, p.Age);
            }

            Console.ReadLine();
        }
    }
}
