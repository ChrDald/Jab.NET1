using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PeopleAgain
{
    class Person
    {
        private String PName;
        private int PAge;

        public Person(String name, int age)
        {
            Name = name;    // Name (capital N) calls the getters/setters for the Name string below, and name (lowercase) refers to the value passed to the constructor
            Age = age;
        }

        public String Name  // c# style getters and setters
        {
            get
            {
                return PName;
            }
            set
            {
                var regex = new Regex(@"(\D|\s){1,20}");    // supposed to be any character except digits, 1 to 20 characters long
                // verify the name has the right format
                if (!regex.IsMatch(value))
                {
                    throw new InvalidDataException("Invalid Name value...");
                }
                else
                {
                    PName = value;
                }
            }
        }
        public int Age
        {
            get
            {
                return PAge;
            }
            set
            {
                if (value > 150 || value < 0)
                {
                    throw new InvalidDataException("Invalid Name value...");
                }
                else
                {
                    PAge = value;
                }
                
            }
        }
    }
        

    class Student : Person
    {
        /*
        public String Program { get; set; } // Auto-Implemented getter/setter syntax
        public double GPA { get; set; } 
        */
        private String SProgram;
        private double SGPA;

        public Student(String name, int age, String program, double gpa) : base(name, age)
        {
            Program = program;
            GPA = gpa;
        }

        public String Program
        {
            get
            {
                return SProgram;
            }
            set
            {
                var regex = new Regex(@"(\D|\s){1,20}");    // supposed to be any character except digits, 1 to 20 characters long
                // verify the program has the right format
                if (!regex.IsMatch(value))
                {
                    throw new InvalidDataException("Invalid Name value...");
                }
                else
                {
                    SProgram = value;
                }
            }
        }
        public double GPA
        {
            get
            {
                return SGPA;
            }
            set
            {
                if (value > 4.3 || value < 0)
                {
                    throw new InvalidDataException("Invalid Name value...");
                }
                else
                {
                    SGPA = value;
                }
            }
        }
        public override String ToString()
        {
            return "Student name: " + Name + " Student Age: " + Age + " Program: " + Program + " GPA: " + GPA;
        }
    }

    class Teacher : Person
    {
        private String TSubject;
        private double TYearsOfExperience;

        public Teacher(String name, int age, String subject, double yearsOfExperience) : base(name, age)
        {
            Subject = subject;
            YearsOfExperience = yearsOfExperience;
        }

        public String Subject
        {
            get
            {
                return TSubject;
            }
            set
            {
                var regex = new Regex(@"(\D|\s){1,20}");    // supposed to be any character except digits, 1 to 20 characters long
                // verify the subject has the right format
                if (!regex.IsMatch(value))
                {
                    throw new InvalidDataException("Invalid Name value...");
                }
                else
                {
                    TSubject = value;
                }
            }
        }
        public double YearsOfExperience
        {
            get
            {
                return TYearsOfExperience;
            }
            set
            {
                if (value > 100 || value < 0)
                {
                    throw new InvalidDataException("Invalid Name value...");
                }
                else
                {
                    TYearsOfExperience = value;
                }
            }
        }

        public override String ToString()
        {
            return "Teacher name: " + Name + " Teacher Age: " + Age + " Teaches: " + Subject + " Experience: " + YearsOfExperience;
        }
    }

    class Program
    {
        static List<Person> PeopleList = new List<Person>();

        static void Main(string[] args)
        {
            
            Student student = new Student("El student", 100, "Program", 3.2);

            Teacher teach = new Teacher("El teacher", 50, "Stuffs", 12);

            Console.WriteLine(teach.ToString());
            Console.WriteLine(student.ToString());
            Console.ReadKey();

            
        }
    }
}
